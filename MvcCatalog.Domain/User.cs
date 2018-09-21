using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace MvcCatalog.Domain
{
    public class User
    {
        protected User()
        {
        }

        public User(string name, string email, string username, string password)
        {
            Contract.Requires<Exception>(name.Length > 3, "Nome inválido");
            Contract.Requires<Exception>(Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z{2,4}"), "E-mail inválido");
            Contract.Requires<Exception>(username.Length > 8, "Username inválido");
            Contract.Requires<Exception>(password.Length > 6, "Senha inválido");

            this.Id = 0;
            this.Name = name;
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Image { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }

        public void ChangeEmail(string email)
        {
            Contract.Requires<Exception>(Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z{2,4}"), "E-mail inválido");
            this.Email = email;
        }

        public void ChangePassword(string username, string password, string newPassword, string confirmPassword)
        {
            Contract.Requires<Exception>(this.Username.ToLower() == username && this.Password == password,"Usuário ou senha inválidos.");
            Contract.Requires<Exception>(newPassword != this.Password, "A nova senha deve ser diferente da atual.");
            Contract.Requires<Exception>(password.Length > 6, "Senha inválido");
            Contract.Requires<Exception>(newPassword == confirmPassword, "As senhas digitadas não coincidem.");

            this.Password = newPassword;
        }

        public void Authenticate(string username, string password)
        {
            Contract.Requires<InvalidOperationException>(this.Username.ToLower() == username, "Usuário inválido");
            Contract.Requires<InvalidOperationException>(this.Password == username, "Senha inválida");
        }

        public void Register(string name, string email, string username, string password, string confirmPassword)
        {
            Contract.Requires<InvalidCastException>(name.Length > 3, "O nome deve conter mais de 3 caracteres.");
            Contract.Requires<InvalidCastException>(Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z{2,4}"), "E-mail inválido.");
            Contract.Requires<InvalidCastException>(username.Length > 6, "Nome de usuário deve ter pelo menos 6 caracteres.");
            Contract.Requires<InvalidCastException>(password.Length > 6, "Senha deve ter pelo menos 6 caracteres.");
            Contract.Requires<InvalidCastException>(password == confirmPassword, "As senhas informadas não coincidem.");

            this.Name = name;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }
    }
}
