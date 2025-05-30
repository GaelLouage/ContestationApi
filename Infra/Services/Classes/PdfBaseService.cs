using Infra.Dtos;
using Infra.Models;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Infra.Services.Classes
{
    public abstract class PdfBaseService
    {
        protected readonly IConfiguration? _config;
        protected readonly IMongoRepository<Issuer> _issuerRepository;
        protected readonly IMongoRepository<Opposer> _opposerRepository;
        protected readonly IMongoRepository<Pdf> _pdfRepository;
        protected readonly IMongoRepository<ResponseBodyEntity> _responseBodyRepository;
        protected readonly IMongoRepository<Response> _responseRepository;

        protected PdfBaseService(
              IConfiguration? config,
            IMongoRepository<Issuer> issuerRepository,
            IMongoRepository<Opposer> opposerRepository,
            IMongoRepository<ResponseBodyEntity> responseBodyRepository,
            IMongoRepository<Pdf> pdfRepository,
            IMongoRepository<Response> responseRepository)
        {
            _config = config;
            _issuerRepository = issuerRepository;
            _opposerRepository = opposerRepository;
            _pdfRepository = pdfRepository;
            _responseBodyRepository = responseBodyRepository;
            _responseRepository = responseRepository;
        }
        protected abstract Task SavePdfAsync(PdfDto pdf);
    }
}
