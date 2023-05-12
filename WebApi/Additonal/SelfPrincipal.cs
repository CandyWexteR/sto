using System.Security.Claims;

namespace WebApi.Additonal;

public class SelfPrincipal : ClaimsPrincipal
{
    private IEnumerable<Claim> _claims;
    public SelfPrincipal(IEnumerable<Claim> claims) : base()
    {
        _claims = claims;
    }

    public override IEnumerable<Claim> Claims => _claims;
}