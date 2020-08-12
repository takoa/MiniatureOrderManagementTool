using DynamicData;
using DynamicData.Binding;
using MiniatureOrderManagementTool.Models.Dtos;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace MiniatureOrderManagementTool.Models
{
    public class PartManager
    {
        private SourceCache<Part, string> partsCache = new SourceCache<Part, string>(p => p.Name);

        public IObservableCollection<Part> ObservableParts { get; } = new ObservableCollectionExtended<Part>();

        public Part[] Parts => this.ObservableParts.ToArray();

        public event Action WhenPartChanged;

        public PartManager()
            : this(null)
        {
        }

        public PartManager(IEnumerable<Part> parts)
        {
            this.partsCache.Connect()
                           .ObserveOn(RxApp.MainThreadScheduler)
                           .Sort(new PartNameComparer())
                           .Bind(this.ObservableParts)
                           .WhenAnyPropertyChanged("Name", "UnitPrice", "Count")
                           .Subscribe(_ => this.WhenPartChanged?.Invoke());

            if (parts != null)
            {
                this.partsCache.AddOrUpdate(parts);
            }
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

        public void AddOrUpdatePart(Part part)
        {
            this.partsCache.AddOrUpdate(part);
        }

        public void RemovePart(Part part)
        {
            this.partsCache.Remove(part);
        }

        public bool TryGetPart(string name, out Part part)
        {
            var p = this.partsCache.Lookup(name);

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
