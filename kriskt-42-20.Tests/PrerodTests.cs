
using kriskt_42_20.Models;
namespace kriskt_42_20.Tests
{
    public class PrerodTests
    {
        [Fact]
        public void IsValidMail_True()
        {
            var MailTest = new Prepod
            {
                Mail = "test@mail.ru"
            };

            var result = MailTest.IsValidMail();

            Assert.False(result);

        }
    }
}