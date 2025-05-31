namespace CasoGestionMatriculas.Operation.Interfaces.REST.Resources
{
    public record CreateStudentResource
        (int Id, string Firstname, string Lastname,
        DateOnly Birthday, string Genre,
        int Phone, string Email);
}