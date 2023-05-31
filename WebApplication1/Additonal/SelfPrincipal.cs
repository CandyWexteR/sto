using System.Security.Claims;

namespace WebApplication1.Additonal;

public class SelfPrincipal : ClaimsPrincipal
{
    private List<Claim> _claims;
    public SelfPrincipal(List<Claim> claims) : base()
    {
        _claims = claims;
    }

    public override IEnumerable<Claim> Claims => _claims;
}