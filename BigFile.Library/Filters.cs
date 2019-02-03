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
        public bool Match()
        {
            var alloweds = new List<bool>(this.Count());
            for (int i = 0; i < this.Count; i++)
            {
                if (!this[i].Match()) return false;
            }
            return true;
        }
    }
}