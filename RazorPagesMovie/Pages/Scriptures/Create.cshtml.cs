﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesScripture.Models;

namespace RazorPagesScripture.Pages.Scriptures
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesScripture.Models.RazorPagesScriptureContext _context;

        public CreateModel(RazorPagesScripture.Models.RazorPagesScriptureContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Scripture Scripture { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Scripture.Add(Scripture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}