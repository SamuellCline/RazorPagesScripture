using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesScripture.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Book { get; set; }

        [Display(Name = "Note Date"), DataType(DataType.Date)]
        public DateTime NoteDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required]
        public string Verse { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Reference { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Note { get; set; }
    }
}