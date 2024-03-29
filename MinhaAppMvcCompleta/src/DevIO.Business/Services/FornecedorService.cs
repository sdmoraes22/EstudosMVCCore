using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        public readonly IFornecedorRepository _fornecedorRepository;
        public readonly IEnderecoRepository _enderecoRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository, 
                                 IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }
        public async Task Adicionar(Fornecedor fornecedor)
        {
            if(!ExecutarValidacao(new FornecedorValidation(), fornecedor) 
                || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;
            
            if(_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any()) 
            {
                Notificar("Já existe um fornecedor com o documento informado");
                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if(!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if(_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any()) 
            {
                Notificar("Já existe um fornecedor com o documento informado");
                return;
            }

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if(!ExecutarValidacao(new EnderecoValidation(), endereco)) return;
            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            if (_fornecedorRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados");
                return;
            }

            var enderecoFornecedor = await _enderecoRepository.ObterEnderecoPorFornecedor(id);


            await _enderecoRepository.Remover(enderecoFornecedor.Id);
            await _fornecedorRepository.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}