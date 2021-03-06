using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace EFCoreIssues.Tests
{
    public class Tests
    {
        [Fact]
        public void Diff()
        {
            // Arrange
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase("in-memory-db");
            using var dbContext = new MyDbContext(dbContextOptionsBuilder.Options);

            var root = new Root()
            {
                A = new A() { Sub = new ASubClass() { AValue = "A Value" } },
                B = new B() { BValue = "B Value" }
            };

            dbContext.Add(root);
            dbContext.SaveChanges();

            // Act
            var result1 = (from r in dbContext.Root
                           select new
                           {
                               r.B.BValue,
                               r.A.Sub.AValue
                           }).FirstOrDefault();

            var result2 = (from r in dbContext.Root
                           select new
                           {
                               r.A.Sub.AValue,
                               r.B.BValue,
                           }).FirstOrDefault();

            // Assert.Equal(result1.BValue, result2.BValue); // Fails

            // Assert
            Assert.Null(result1.BValue);
            Assert.NotNull(result2.BValue);
        }
    }
}
