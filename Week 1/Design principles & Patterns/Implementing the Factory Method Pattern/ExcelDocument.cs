using System;

namespace FactoryMethodPattern
{
    public class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Excel document.");
        }
    }
}
