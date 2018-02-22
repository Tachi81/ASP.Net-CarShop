using System;

namespace CarShop.Interfaces
{
    public interface IBasicEntity
    {  
        DateTime DateCreate { get; set; }
        DateTime Modificationdate { get; set; }
        string RecordAuthor { get; set; }
        string RecordModificationAuthor { get; set; }
        bool IsActive { get; set; }
    }
}