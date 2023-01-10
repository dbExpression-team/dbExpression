using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Assembler;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Assembler
{
    public class AppenderTests : TestBase
    {
        private static string[] contentSegments = new string[]
        {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed vulputate odio ut enim blandit volutpat maecenas. Lacus laoreet "
            + "non curabitur gravida arcu ac tortor dignissim convallis. Ac turpis egestas maecenas pharetra convallis posuere morbi. Quisque sagittis purus sit amet volutpat consequat. Eu sem integer vitae justo. "
            + "Tellus in hac habitasse platea dictumst vestibulum. Sed risus pretium quam vulputate dignissim. Massa id neque aliquam vestibulum morbi blandit cursus risus at. Vel eros donec ac odio tempor orci dapibus. "
            + "Semper viverra nam libero justo laoreet sit. Etiam tempor orci eu lobortis. Arcu odio ut sem nulla pharetra. Consectetur lorem donec massa sapien faucibus et molestie ac feugiat. Habitant morbi tristique ",
            "senectus et. Aliquam malesuada bibendum arcu vitae. Dolor purus non enim praesent elementum facilisis leo.  Interdum varius sit amet mattis vulputate. Gravida rutrum quisque non tellus. In pellentesque massa "
            + "placerat duis ultricies. Sit amet nisl purus in mollis nunc. In est ante in nibh mauris cursus mattis molestie. Sollicitudin tempor id eu nisl nunc mi. Lacus luctus accumsan tortor posuere ac. Ut venenatis "
            + "tellus in metus vulputate eu. Auctor urna nunc id cursus metus aliquam. Nisl nunc mi ipsum faucibus vitae aliquet nec. Ultrices neque ornare aenean euismod elementum. Proin libero nunc consequat interdum varius. "
            + "Dignissim cras tincidunt lobortis feugiat. At augue eget arcu dictum varius duis at consectetur. Maecenas sed enim ut sem. Potenti nullam ac tortor vitae purus faucibus ornare suspendisse.  At imperdiet dui ",
            "accumsan sit amet. Gravida dictum fusce ut placerat. Volutpat sed cras ornare arcu dui. At ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget. In massa tempor nec feugiat. Fames ac turpis "
            + "egestas integer eget aliquet nibh. Augue neque gravida in fermentum et sollicitudin ac orci phasellus. Non tellus orci ac auctor. Morbi non arcu risus quis. Condimentum lacinia quis vel eros. Velit "
            + "scelerisque in dictum non consectetur a erat. Semper auctor neque vitae tempus quam pellentesque nec nam aliquam. Facilisis volutpat est velit egestas dui id ornare. Nunc congue nisi vitae suscipit tellus "
            + "mauris a. Risus pretium quam vulputate dignissim suspendisse. Congue nisi vitae suscipit tellus mauris a. Faucibus ornare suspendisse sed nisi lacus. Mi quis hendrerit dolor magna.  Et leo duis ut diam ",
            "quam nulla porttitor massa. Donec ac odio tempor orci. Dolor purus non enim praesent elementum facilisis leo vel. Nullam ac tortor vitae purus faucibus ornare. Pretium aenean pharetra magna ac placerat "
            + "vestibulum. Lacus luctus accumsan tortor posuere ac ut consequat semper viverra. Turpis in eu mi bibendum neque egestas congue. In arcu cursus euismod quis viverra nibh cras. Vestibulum mattis ullamcorper "
            + "velit sed ullamcorper. Ullamcorper eget nulla facilisi etiam. Viverra orci sagittis eu volutpat odio. Consectetur adipiscing elit ut aliquam purus sit amet luctus venenatis. Vitae congue eu consequat ac. ",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed vulputate odio ut enim blandit volutpat maecenas. Lacus laoreet "
            + "non curabitur gravida arcu ac tortor dignissim convallis. Ac turpis egestas maecenas pharetra convallis posuere morbi. Quisque sagittis purus sit amet volutpat consequat. Eu sem integer vitae justo. "
            + "Tellus in hac habitasse platea dictumst vestibulum. Sed risus pretium quam vulputate dignissim. Massa id neque aliquam vestibulum morbi blandit cursus risus at. Vel eros donec ac odio tempor orci dapibus. "
            + "Semper viverra nam libero justo laoreet sit. Etiam tempor orci eu lobortis. Arcu odio ut sem nulla pharetra. Consectetur lorem donec massa sapien faucibus et molestie ac feugiat. Habitant morbi tristique ",
            "senectus et. Aliquam malesuada bibendum arcu vitae. Dolor purus non enim praesent elementum facilisis leo.  Interdum varius sit amet mattis vulputate. Gravida rutrum quisque non tellus. In pellentesque massa "
            + "placerat duis ultricies. Sit amet nisl purus in mollis nunc. In est ante in nibh mauris cursus mattis molestie. Sollicitudin tempor id eu nisl nunc mi. Lacus luctus accumsan tortor posuere ac. Ut venenatis "
            + "tellus in metus vulputate eu. Auctor urna nunc id cursus metus aliquam. Nisl nunc mi ipsum faucibus vitae aliquet nec. Ultrices neque ornare aenean euismod elementum. Proin libero nunc consequat interdum varius. "
            + "Dignissim cras tincidunt lobortis feugiat. At augue eget arcu dictum varius duis at consectetur. Maecenas sed enim ut sem. Potenti nullam ac tortor vitae purus faucibus ornare suspendisse.  At imperdiet dui ",
            "accumsan sit amet. Gravida dictum fusce ut placerat. Volutpat sed cras ornare arcu dui. At ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget. In massa tempor nec feugiat. Fames ac turpis "
            + "egestas integer eget aliquet nibh. Augue neque gravida in fermentum et sollicitudin ac orci phasellus. Non tellus orci ac auctor. Morbi non arcu risus quis. Condimentum lacinia quis vel eros. Velit "
            + "scelerisque in dictum non consectetur a erat. Semper auctor neque vitae tempus quam pellentesque nec nam aliquam. Facilisis volutpat est velit egestas dui id ornare. Nunc congue nisi vitae suscipit tellus "
            + "mauris a. Risus pretium quam vulputate dignissim suspendisse. Congue nisi vitae suscipit tellus mauris a. Faucibus ornare suspendisse sed nisi lacus. Mi quis hendrerit dolor magna.  Et leo duis ut diam ",
            "quam nulla porttitor massa. Donec ac odio tempor orci. Dolor purus non enim praesent elementum facilisis leo vel. Nullam ac tortor vitae purus faucibus ornare. Pretium aenean pharetra magna ac placerat "
            + "vestibulum. Lacus luctus accumsan tortor posuere ac ut consequat semper viverra. Turpis in eu mi bibendum neque egestas congue. In arcu cursus euismod quis viverra nibh cras. Vestibulum mattis ullamcorper "
            + "velit sed ullamcorper. Ullamcorper eget nulla facilisi etiam. Viverra orci sagittis eu volutpat odio. Consectetur adipiscing elit ut aliquam purus sit amet luctus venenatis. Vitae congue eu consequat ac."
        };

        private static string GetJoinedContent(int segmentCount)
        {
            var output = string.Empty;
            for (var i = 0; i < segmentCount; i++)
            {
                output += contentSegments[i];
            }
            return output;
        } 
        
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_appender_build_correct_output(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            var appender = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IAppender>();

            for (var i = 0; i < contentSegments.Length; i++)
            {
                appender.Write(contentSegments[i]);
            }

            var appended = appender.ToString();

            //then

            appended.Should().Be(GetJoinedContent(contentSegments.Length));
        }
        
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_multiple_appenders_buid_correct_output(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            var appender1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IAppender>();
            var appender2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IAppender>();
            var appender3 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IAppender>();
            
            for (var i = 0; i < contentSegments.Length; i++)
            {
                appender1.Write(contentSegments[i]);
            }
            var appended1 = appender1.ToString();
            appender1.Dispose();
            
            for (var i = 0; i < contentSegments.Length; i++)
            {
                appender2.Write(contentSegments[i]);
            }
            var appended2 = appender2.ToString();
            appender2.Dispose();
            
            for (var i = 0; i < contentSegments.Length; i++)
            {
                appender3.Write(contentSegments[i]);
            }
            var appended3 = appender3.ToString();
            appender3.Dispose();
            
            //then
            appended1.Should().Be(appended2);
            appended2.Should().Be(appended3);
        }
    }
}