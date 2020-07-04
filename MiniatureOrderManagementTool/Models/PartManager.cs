using DynamicData;
using MiniatureOrderManagementTool.Dtos;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace MiniatureOrderManagementTool.Models
{
    public class PartManager
    {
        public SourceCache<Part, string> PartsCache { get; private set; }

        private ReadOnlyObservableCollection<Part> observableParts;
        public ReadOnlyObservableCollection<Part> ObservableParts => this.observableParts;

        public Part[] Parts
        {
            get => this.ObservableParts.ToArray();
            set
            {
                if (value != null)
                {
                    this.PartsCache.AddOrUpdate(value);
                }
            }
        }

        public int TotalPartCount
        {
            get
            {
                var count = 0;

                foreach (var item in this.ObservableParts)
                {
                    count += item.Count;
                }

                return count;
            }
        }

        public PartManager()
        {
            this.PartsCache = new SourceCache<Part, string>(p => p.Name);
            this.PartsCache.Connect()
                           .ObserveOn(RxApp.MainThreadScheduler)
                           .Sort(new PartNameComparer())
                           .Bind(out this.observableParts)
                           .Subscribe();
        }

        public static int GetPartAmountInt(string str)
        {

            if (Int32.TryParse(str, out int i))
            {
                return i;
            }
            else if (str == "" || i < 0)
            {
                return 0;
            }
            else
            {
                return int.MaxValue;
            }
        }

        public void AddPart(Part part)
        {
            this.PartsCache.AddOrUpdate(part);
        }

        public void RemovePart(Part part)
        {
            this.PartsCache.Remove(part);
        }
    }
}
