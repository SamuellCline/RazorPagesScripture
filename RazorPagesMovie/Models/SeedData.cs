using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesScripture.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesScriptureContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesScriptureContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

               
                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Book of Mormon",
                        NoteDate = DateTime.Parse("1989-2-12"),
                        Verse = "47 And again, the Lord has said that: Ye shall defend your families even unto bloodshed. Therefore for this cause were the Nephites contending with the Lamanites, to defend themselves, and their families, and their lands, their country, and their rights, and their religion.",
                        Reference = "Alma 43:47",
                        Note = "This is a good one for Lesson next sunday."
                    },
               

                    new Scripture
                    {
                        Book = "New Testament",
                        NoteDate = DateTime.Parse("1984-3-13"),
                        Verse = "35 Jesus wept.",
                        Reference = "John 11:35",
                        Note = "The shortest verse in the Bible."
                    },

                    new Scripture
                    {
                        Book = "Book of Mormon",
                        NoteDate = DateTime.Parse("1986-2-23"),
                        Verse = "1 I, Nephi, having been born of goodly parents, therefore I was taught somewhat in all the learning of my father; and having seen many afflictions in the course of my days, nevertheless, having been highly favored of the Lord in all my days; yea, having had a great knowledge of the goodness and the mysteries of God, therefore I make a record of my proceedings in my days.",
                        Reference = "1 Nephi 1:1",
                        Note = "This is the first verse in the Book of Mormon."
                    },

                    new Scripture
                    {
                        Book = "New Testament",
                        NoteDate = DateTime.Parse("1959-4-15"),
                        Verse = "13 When Jesus came into the coasts of Cæsarea Philippi, he asked his disciples, saying, Whom do men say that I the Son of man am? 14 And they said, Some say that thou art John the Baptist: some, Elias; and others, Jeremias, or one of the prophets. 15 He saith unto them, But whom say ye that I am? 16 And Simon Peter answered and said, Thou art the Christ, the Son of the living God. 17 And Jesus answered and said unto him, Blessed art thou, Simon Bar-jona: for flesh and blood hath not revealed it unto thee, but my Father which is in heaven.",
                        Reference = "Matthew 16:13-17",
                        Note = "Use for Talk next month."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
