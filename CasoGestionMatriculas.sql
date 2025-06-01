CREATE DATABASE CasoGestionMatriculas
GO

USE CasoGestionMatriculas
GO

CREATE TABLE courses
(
	id int identity(1,1) NOT NULL,
	name varchar(100) NOT NULL,

	CONSTRAINT pk_course_id PRIMARY KEY (id)
)
GO
CREATE TABLE students
(
	id int NOT NULL,
	firstname varchar(100) NOT NULL,
	lastname varchar(100) NOT NULL,
	birthday date NOT NULL,
	genre varchar(20) NOT NULL,
	phone int NOT NULL,
	email varchar(100) NOT NULL

	CONSTRAINT pk_student_id PRIMARY KEY (id)
)
GO
CREATE TABLE registrations
(
	id int identity(1,1) NOT NULL,
	courses_id int NOT NULL,
	students_id int NOT NULL,
	enrollment_date date NOT NULL,
	state varchar(20) NOT NULL

	CONSTRAINT pk_registration_id PRIMARY KEY (id)

	CONSTRAINT fk_registrations_courses_id FOREIGN KEY (courses_id)
	REFERENCES courses(id),

	CONSTRAINT fk_registrations_students_id FOREIGN KEY (students_id)
	REFERENCES students(id),

	CONSTRAINT chk_registration_state CHECK (state IN ('ACTIVA', 'CANCELADA', 'FINALIZADA'))
)
GO

CREATE PROCEDURE sp_update_registration
(
    @id int,
    @state varchar(20)
)
AS
BEGIN

    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM registrations WHERE id = @id)
    BEGIN
        RAISERROR('La inscripción no existe.', 16, 1);
        RETURN;
    END

    DECLARE @current_state VARCHAR(20);
    SELECT @current_state = state FROM registrations WHERE id = @id;


    IF @current_state = 'FINALIZADA' AND @state = 'CANCELADA'
    BEGIN
        RAISERROR('No se puede cancelar una inscripción ya finalizada.', 16, 1);
        RETURN;
    END

    UPDATE registrations SET state = @state WHERE id = @id;

END
GO
CREATE PROCEDURE sp_delete_registration
(
    @id int
)
AS
BEGIN

    SET NOCOUNT ON;

    DECLARE @state VARCHAR(20);
    SELECT @state = state FROM registrations WHERE id = @id;

    IF @state IS NULL
    BEGIN
        RAISERROR('La inscripción no existe.', 16, 1);
        RETURN;
    END

    IF @state <> 'CANCELADA'
    BEGIN
        RAISERROR('Solo se puede eliminar una inscripción cancelada.', 16, 1);
        RETURN;
    END

    DELETE FROM registrations WHERE id = @id;

END
GO