using System;
using System.Collections;
using System.Collections.Generic;

namespace kursach.Controls.Search
{
    public class SearchResult
    {
        public Type Type { get; }
        public IEnumerable Result { get; }

        public SearchResult(Type t, IEnumerable r)
        {
            Type = t;
            Result = r;
        }
        
    }
}