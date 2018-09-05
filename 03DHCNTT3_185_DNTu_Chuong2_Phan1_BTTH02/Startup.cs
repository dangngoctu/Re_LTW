using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Startup))]
namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
