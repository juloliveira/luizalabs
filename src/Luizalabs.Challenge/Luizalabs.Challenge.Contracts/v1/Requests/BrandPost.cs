using Luizalabs.Challenge.Core;

namespace Luizalabs.Challenge.Contracts.v1.Requests
{
    public class BrandPost
    {
        public string Name { get; set; }

        public Brand CreateDomain()
        {
            return new Brand {  Name = this.Name };
        }
    }
}
