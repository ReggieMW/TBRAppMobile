using System;
using System.Collections.Generic;

namespace TBRAppMobile.Models
{
    public static class BookStatusHelper
    {
        public static List<BookStatus> BookStatusValues { get; } = new()
        {
            BookStatus.TBR,
            BookStatus.CurrentReads,
            BookStatus.Read,
            BookStatus.DNF
        };
    }
}
