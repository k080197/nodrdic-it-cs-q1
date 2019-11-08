using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Classwork
{
    class ErrorList : IDisposable, IEnumerable<string>
    {
        public readonly string Category;
        public List<String> Errors { get; set; }
        public void Dispose()
        {
            Errors.Clear();
            Errors = null;
        }
        public ErrorList(string category, List<string> errors)
        {
            Category = category;
            Errors = errors;
        }
        public void Add(string errorMessage)
        {
            Errors.Add(errorMessage);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return Errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
