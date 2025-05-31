namespace CasoGestionMatriculas.Operation.Domain.Model.Commands
{
    public record CreateStudentCommand
        (int Id, string Firstname, string Lastname,
        DateOnly Birthday, string Genre,
        int Phone, string Email);
}