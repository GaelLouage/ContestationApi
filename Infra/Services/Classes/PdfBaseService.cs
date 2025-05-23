using Infra.Models;
using Infra.Repositories.Interfaces;

namespace Infra.Services.Classes
{
    public abstract class PdfBaseService
    {
        protected readonly IMongoRepository<Issuer> _issuerRepository;
        protected readonly IMongoRepository<Opposer> _opposerRepository;
        protected readonly IMongoRepository<ResponseBodyEntity> _responseBodyRepository;
        protected readonly IMongoRepository<Response> _responseRepository;

        protected PdfBaseService(
            IMongoRepository<Issuer> issuerRepository, 
            IMongoRepository<Opposer> opposerRepository, 
            IMongoRepository<ResponseBodyEntity> responseBodyRepository, 
            IMongoRepository<Response> responseRepository)
        {
            _issuerRepository = issuerRepository;
            _opposerRepository = opposerRepository;
            _responseBodyRepository = responseBodyRepository;
            _responseRepository = responseRepository;
        }
    }
}
