function AjaxModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({cache: false});

            $('a[data-modal]').on('click', function(e) {
                $('#myModalContent').load(this.href, function() {
                    $('#myModal').modal({ keyboard: true },'show');
                    bindForm(this);
                });
                return false
            });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function() {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function(result) {
                        if(result.success) {
                            $('#myModal').modal('hide');
                            $('#EnderecoTarget').load(result.url);
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }
    });
}

function BuscaCep() {
    $(document).ready(function() {
        function limpaFormularioCep() {
            //Limpa os valores do formulário de cep
            $('#Endereco_Logradouro').val('');
            $('#Endereco_Bairro').val('');
            $('#Endereco_Cidade').val('');
            $('#Endereco_Estado').val('');
        }

        $('#Endereco_Cep').on('blur', function() {
            var cep = $(this).val().replace(/\D/g, '');

            if(cep != '') {
                var validaCep = /^[0-9]{8}$/;

                if(validaCep.test(cep)) {
                    $('#Endereco_Logradouro').val('...');
                    $('#Endereco_Bairro').val('...');
                    $('#Endereco_Cidade').val('...');
                    $('#Endereco_Estado').val('...');

                    $.getJSON('https://viacep.com.br/ws/' + cep + '/json/?callback=?',
                        function(dados) {
                            if(!('erro' in dados)) {
                                $('#Endereco_Logradouro').val(dados.logradouro);
                                $('#Endereco_Bairro').val(dados.bairro);
                                $('#Endereco_Cidade').val(dados.localidade);
                                $('#Endereco_Estado').val(dados.uf);
                            } else {
                                limpaFormularioCep();
                                alert('Cep não encontrado');
                            }
                        });
                } else {
                    limpaFormularioCep();
                    alert('Formato de cep inválido');
                }
            } else {
                limpaFormularioCep();
            }
        });
    });
}

$(document).ready(function(){
    $('#msg_box').fadeOut(2500);
});