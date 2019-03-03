using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesScripture.Models;

namespace RazorPagesScripture.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesScripture.Models.RazorPagesScriptureContext _context;

        public IndexModel(RazorPagesScripture.Models.RazorPagesScriptureContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Verses { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureVerse { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of Verses.
            IQueryable<string> VerseQuery = from m in _context.Scripture
                                            orderby m.Book
                                            select m.Book;

            var var1 = from m in _context.Scripture
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                var1 = var1.Where(s => s.Note.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureVerse))
            {
                var1 = var1.Where(x => x.Note == ScriptureVerse);
            }
            Verses = new SelectList(await VerseQuery.Distinct().ToListAsync());
            Scripture = await var1.ToListAsync();
        }
    }
}
