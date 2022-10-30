using FileDoc.Interfaces;
using FileDoc.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Services
{
    public class DocumentListSvc : IDocumentList
    {
        protected DataContext _context;

        public DocumentListSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddDocumentList(DocumentList DocumentLists)
        {
            _context.Add(DocumentLists);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditDocumentList(int id, DocumentList DocumentLists)
        {
            _context.documentLists.Update(DocumentLists);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DocumentList>> GetDocumentListAll()
        {
            var dataContext = _context.documentLists;
            return await dataContext.ToListAsync();
        }

        public async Task<DocumentList> GetDocumentList(int? id)
        {
            var DocumentLists = await _context.documentLists
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (DocumentLists == null)
            {
                return null;
            }

            return DocumentLists;
        }

    }
}

