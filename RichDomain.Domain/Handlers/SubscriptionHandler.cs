using System;
using Flunt.Notifications;
using RichDomains.Domain.Commands;
using RichDomains.Domain.EDocumentTypes;
using RichDomains.Domain.Repositories;
using RichDomains.Domain.ValueObjetcs;
using RichDomains.Shared.Commands;
using RichDomains.Shared.Handlers;

namespace RichDomains.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>, IHandler<CreatePayPalSubscriptionCommand>, IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly Services.IEmailService _emailService;
        public SubscriptionHandler(IStudentRepository repository, Services.IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if(command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }
            
            //Verificar se Documento já está cadastrado
            if(_repository.DocumentExists(command.PayerDocument))
                AddNotification("Document", "Este CPF já está em uso");
            
        
            //Verificar se E-mail já está cadastrados            
            if(_repository.EmailExists(command.PayerEmail))
                AddNotification("Email", "Este E-mail já está em uso");

        
            //Gerar os values Objects (VOs)
            var name = new Name (command.FirstName, command.LastName);
            var document = new Document(command.PayerDocument, EDocumentType.CPF);
            var email = new Email (command.PayerEmail);
            var address = new Address(command.Stret, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.zipCode);

            //Gerar as entidades
            var student = new Entities.Student(name, email, document);
            var subscription = new Entities.Subscription(DateTime.Now.AddMonths(1));
            var payment = new Entities.BoletoPayment(command.BarCode, command.BoletoNumber, command.Number,
            command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer,
            new Document(command.Payer, command.PayerDocumentType), address, email);
            
            // Adiciona os Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupa as validações
            AddNotifications(name, document, address, student, subscription, payment);

            //Checar as infos
            if(Invalid)
                new CommandResult(false, "Assinatura realizada com suesso");

            // Salvar as validações
            _repository.CreateSubscription(student);

            //Enviar E-mail de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address ,"Bem vindo ao Beludo", "Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");


        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {   
            //Verificar se Documento já está cadastrado
            if(_repository.DocumentExists(command.PayerDocument))
                AddNotification("Document", "Este CPF já está em uso");
            
        
            //Verificar se E-mail já está cadastrados            
            if(_repository.EmailExists(command.PayerEmail))
                AddNotification("Email", "Este E-mail já está em uso");

        
            //Gerar os values Objects (VOs)
            var name = new Name (command.FirstName, command.LastName);
            var document = new Document(command.PayerDocument, EDocumentType.CPF);
            var email = new Email (command.PayerEmail);
            var address = new Address(command.Stret, command.Number, command.Neighborhood, command.City, command.State, command.Contry, command.zipCode);

            //Gerar as entidades
            var student = new Entities.Student(name, email, document);
            var subscription = new Entities.Subscription(DateTime.Now.AddMonths(1));
            var PayPalpayment = new Entities.PayPalPayment(command.TransactionCode, command.Number,
            command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer,
            new Document(command.Payer, command.PayerDocumentType), address, email);
            
            // Adiciona os Relacionamentos
            subscription.AddPayment(PayPalpayment);
            student.AddSubscription(subscription);

            // Agrupa as validações
            AddNotifications(name, document, address, student, subscription, PayPalpayment);
            
            //checar as notes
             if(Invalid)
                new CommandResult(false, "Assinatura realizada com suesso");
            // Salvar as validações
            _repository.CreateSubscription(student);

            //Enviar E-mail de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address ,"Bem vindo ao Beludo", "Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");

        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            //Verificar se Documento já está cadastrado
            if(_repository.DocumentExists(command.PayerDocument))
                AddNotification("Document", "Este CPF já está em uso");
            
        
            //Verificar se E-mail já está cadastrados            
            if(_repository.EmailExists(command.PayerEmail))
                AddNotification("Email", "Este E-mail já está em uso");

        
            //Gerar os values Objects (VOs)
            var name = new Name (command.FirstName, command.LastName);
            var document = new Document(command.PayerDocument, EDocumentType.CPF);
            var email = new Email (command.PayerEmail);
            var address = new Address(command.Stret, command.Number, command.Neighborhood, command.City, command.State, command.Contry, command.zipCode);

            //Gerar as entidades
            var student = new Entities.Student(name, email, document);
            var subscription = new Entities.Subscription(DateTime.Now.AddMonths(1));
            var CreditCarpayment = new Entities.PayPalPayment(command.LastTransictionNumber, command.Number,
            command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer,
            new Document(command.Payer, command.PayerDocumentType), address, email);
            
            // Adiciona os Relacionamentos
            subscription.AddPayment(CreditCarpayment);
            student.AddSubscription(subscription);

            // Agrupa as validações
            AddNotifications(name, document, address, student, subscription, CreditCarpayment);

            //checar as infos
             if(Invalid)
                new CommandResult(false, "Assinatura realizada com suesso");

            // Salvar as validações
            _repository.CreateSubscription(student);

            //Enviar E-mail de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address ,"Bem vindo ao Beludo", "Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}