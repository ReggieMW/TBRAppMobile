using System;
using System.Collections.Generic;

namespace TBRAppMobile.Models
{

    //This is a read-only static list of BookStatus enum values. Used for pickers
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
