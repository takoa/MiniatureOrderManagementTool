using DynamicData;
using DynamicData.Binding;
using MiniatureOrderManagementTool.Models.Dtos;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;

namespace MiniatureOrderManagementTool.Models
{
    public class PartManager
    {
        public SourceCache<Part, string> PartsCache { get; private set; }

        public IObservableCollection<Part> ObservableParts { get; } = new ObservableCollectionExtended<Part>();

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

        public event Action WhenPartChanged;

        public PartManager()
        {
            this.PartsCache = new SourceCache<Part, string>(p => p.Name);
            this.PartsCache.Connect()
                           .ObserveOn(RxApp.MainThreadScheduler)
                           .Sort(new PartNameComparer())
                           .Bind(this.ObservableParts)
                           .WhenAnyPropertyChanged("Name", "UnitPrice", "Count")
                           .Subscribe(_ => this.WhenPartChanged?.Invoke());
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

        public static string GetTotalPartCountString(int totalPartCount)
        {
            return totalPartCount + "個";
        }

        public static string GetTotalPartValueString(decimal totalPartValue)
        {
            return totalPartValue + "円";
        }

        public void AddPart(Part part)
        {
            this.PartsCache.AddOrUpdate(part);
        }

        public void RemovePart(Part part)
        {
            this.PartsCache.Remove(part);
        }

        public bool TryGetPart(string name, out Part part)
        {
            var p = this.PartsCache.Lookup(name);

            if (p.HasValue)
            {
                part = p.Value;

                return true;
            }
            else
            {
                part = null;

                return false;
            }
        }
    }
}
