using System.Collections.Generic;

namespace WebKrpcApi.Services.Mapping.Dtos
{
    /// <summary>
    /// DTO que encapsula o resultado de operações de autenticação.
    /// </summary>
    public class AuthenticationResultDto
    {
        /// <summary>
        /// Indica se a autenticação foi bem-sucedida.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Lista de mensagens de erro associadas à falha na autenticação.
        /// Nota: Os erros serão apresentados ao usuário, portanto, devem ser claros e seguros para exibição pública.
        /// </summary>
        public IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// Token de acesso gerado após uma autenticação bem-sucedida. Este token deve ser armazenado com segurança.
        /// Exemplo: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Mensagem adicional para fornecer feedback ao usuário. Pode ser usado para transmitir informações não críticas.
        /// Exemplo: "Sua autenticação foi bem-sucedida e agora você tem acesso ao sistema."
        /// </summary>
        public string Message { get; set; }
    }
}