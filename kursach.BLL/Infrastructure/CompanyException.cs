using System;

namespace kursach.BLL.Infrastructure
{
    public class CompanyException : Exception
    {
        public CompanyException(string message) : base(message)
        {
        }
    }
}