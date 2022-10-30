using FileDoc.Model;
using FileDoc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Interfaces
{
    public interface IDocumentList
    {
        Task<List<DocumentList>> GetDocumentListAll();
        Task<bool> EditDocumentList(int id, DocumentList DocumentLists);
        Task<bool> AddDocumentList(DocumentList DocumentLists);
        Task<DocumentList> GetDocumentList(int? id);
    }
}
