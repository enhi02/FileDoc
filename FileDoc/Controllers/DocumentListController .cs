using FileDoc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDoc.Models;
using FileDoc.Models.ViewModel;
//using FileDoc.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using FileDoc.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FileDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DocumentListController : ControllerBase
    {
        private readonly IDocumentList _document;
        private readonly DataContext _context;
        public DocumentListController(DataContext context, IDocumentList document)
        {
            _context = context;
            _document = document;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddDocument(DocumentList document)
        {
            try
            {
                await _document.AddDocumentList(document);
            }
            catch (Exception ex)
            {

            }
            return Ok(new
            {
                retCode = 1,
                retText = "Thêm thành công"
            });
        }
        [HttpGet]
        [Route("ListDocument")]
        public async Task<ActionResult<IEnumerable<DocumentList>>> GetDocumentAllAsync()
        {
            return await _document.GetDocumentListAll();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(int id, DocumentList document)
        {
            if (id != document.DocumentId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _document.EditDocumentList(id, document);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Sửa thành công"
                 });
        }
        private bool DocumentExists(int id)
        {
            return _context.groupPermissions.Any(e => e.GroupId == id);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var Document = await _context.documentLists.FindAsync(id);
            if (Document == null)
            {
                return NotFound();
            }

            _context.documentLists.Remove(Document);
            await _context.SaveChangesAsync();

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Xóa thành công"
                 });
        }
    }
}
