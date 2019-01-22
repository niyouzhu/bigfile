using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BigFile.Library
{
    public class Filters : Collection<IFilter>
    {
        public bool Allow()
        {
            var alloweds = new List<bool>(this.Count());
            foreach (var filter in this)
            {
                alloweds.Add(filter.Allow());
            }
            return !alloweds.Contains(false);
        }
    }
}