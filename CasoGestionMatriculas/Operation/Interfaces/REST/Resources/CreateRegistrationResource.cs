﻿namespace CasoGestionMatriculas.Operation.Interfaces.REST.Resources
{
    public record CreateRegistrationResource
        (int CourseId, int StudentId,
        DateOnly EnrollmentDate, string State);
}