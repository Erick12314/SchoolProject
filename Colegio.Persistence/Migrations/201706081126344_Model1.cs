namespace Colegio.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnos",
                c => new
                    {
                        AlumnoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 200),
                        ApellidoMaterno = c.String(nullable: false, maxLength: 200),
                        TipoDocumento = c.Byte(nullable: false),
                        NumeroDocumento = c.Long(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        Sexo = c.Byte(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Usuario = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        DireccionId = c.Int(nullable: false),
                        NivelId = c.Int(nullable: false),
                        GradoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlumnoId)
                .ForeignKey("dbo.Direcciones", t => t.DireccionId, cascadeDelete: true)
                .ForeignKey("dbo.Grados", t => t.GradoId, cascadeDelete: true)
                .ForeignKey("dbo.Niveles", t => t.NivelId, cascadeDelete: true)
                .Index(t => t.DireccionId)
                .Index(t => t.NivelId)
                .Index(t => t.GradoId);
            
            CreateTable(
                "dbo.Apoderados",
                c => new
                    {
                        ApoderadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        Apellidos = c.String(nullable: false, maxLength: 500),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        Correo = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ApoderadoId);
            
            CreateTable(
                "dbo.Asistencias",
                c => new
                    {
                        AsistenciaId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        AlumnoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsistenciaId)
                .ForeignKey("dbo.Alumnos", t => t.AlumnoId, cascadeDelete: true)
                .Index(t => t.AlumnoId);
            
            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        DireccionId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        DistritoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DireccionId)
                .ForeignKey("dbo.Distritos", t => t.DistritoId, cascadeDelete: true)
                .Index(t => t.DistritoId);
            
            CreateTable(
                "dbo.Distritos",
                c => new
                    {
                        DistritoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.DistritoId);
            
            CreateTable(
                "dbo.Profesores",
                c => new
                    {
                        ProfesorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 200),
                        ApellidoMaterno = c.String(nullable: false, maxLength: 200),
                        TipoDocumento = c.Byte(nullable: false),
                        NumeroDocumento = c.Long(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        Sexo = c.Byte(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Usuario = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        DireccionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfesorId)
                .ForeignKey("dbo.Direcciones", t => t.DireccionId, cascadeDelete: true)
                .Index(t => t.DireccionId);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        AreaCurricularId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursoId)
                .ForeignKey("dbo.AreasCurriculares", t => t.AreaCurricularId, cascadeDelete: true)
                .Index(t => t.AreaCurricularId);
            
            CreateTable(
                "dbo.AreasCurriculares",
                c => new
                    {
                        AreaCurricularId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.AreaCurricularId);
            
            CreateTable(
                "dbo.Aulas",
                c => new
                    {
                        AulaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Seccion = c.String(nullable: false, maxLength: 1),
                        GradoId = c.Int(nullable: false),
                        NivelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AulaId)
                .ForeignKey("dbo.Grados", t => t.GradoId, cascadeDelete: true)
                .ForeignKey("dbo.Niveles", t => t.NivelId, cascadeDelete: true)
                .Index(t => t.GradoId)
                .Index(t => t.NivelId);
            
            CreateTable(
                "dbo.Grados",
                c => new
                    {
                        GradoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.GradoId);
            
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        HorarioId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 300),
                        GradoId = c.Int(nullable: false),
                        NivelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HorarioId)
                .ForeignKey("dbo.Niveles", t => t.NivelId, cascadeDelete: true)
                .ForeignKey("dbo.Grados", t => t.GradoId)
                .Index(t => t.GradoId)
                .Index(t => t.NivelId);
            
            CreateTable(
                "dbo.Niveles",
                c => new
                    {
                        NivelId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.NivelId);
            
            CreateTable(
                "dbo.Sesiones",
                c => new
                    {
                        SesionId = c.Int(nullable: false, identity: true),
                        Dia = c.Byte(nullable: false),
                        Actividad = c.String(maxLength: 300),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFin = c.DateTime(nullable: false),
                        CursoId = c.Int(nullable: false),
                        ProfesorId = c.Int(nullable: false),
                        AulaId = c.Int(nullable: false),
                        HorarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SesionId)
                .ForeignKey("dbo.Aulas", t => t.AulaId, cascadeDelete: true)
                .ForeignKey("dbo.Cursos", t => t.CursoId)
                .ForeignKey("dbo.Profesores", t => t.ProfesorId, cascadeDelete: true)
                .ForeignKey("dbo.Horarios", t => t.HorarioId)
                .Index(t => t.CursoId)
                .Index(t => t.ProfesorId)
                .Index(t => t.AulaId)
                .Index(t => t.HorarioId);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        MatriculaId = c.Int(nullable: false, identity: true),
                        Year = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                        AlumnoId = c.Int(nullable: false),
                        AulaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatriculaId)
                .ForeignKey("dbo.Alumnos", t => t.AlumnoId, cascadeDelete: true)
                .ForeignKey("dbo.Aulas", t => t.AulaId)
                .Index(t => t.AlumnoId)
                .Index(t => t.AulaId);
            
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        NotaId = c.Int(nullable: false, identity: true),
                        Puntaje = c.Double(nullable: false),
                        AlumnoId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                        EvaluacionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotaId)
                .ForeignKey("dbo.Alumnos", t => t.AlumnoId, cascadeDelete: true)
                .ForeignKey("dbo.Cursos", t => t.CursoId)
                .ForeignKey("dbo.Evaluaciones", t => t.EvaluacionId, cascadeDelete: true)
                .Index(t => t.AlumnoId)
                .Index(t => t.CursoId)
                .Index(t => t.EvaluacionId);
            
            CreateTable(
                "dbo.Evaluaciones",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 100),
                        TipoEvaluacionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluacionId)
                .ForeignKey("dbo.TiposEvaluaciones", t => t.TipoEvaluacionId, cascadeDelete: true)
                .Index(t => t.TipoEvaluacionId);
            
            CreateTable(
                "dbo.TiposEvaluaciones",
                c => new
                    {
                        TipoEvaluacionId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.TipoEvaluacionId);
            
            CreateTable(
                "dbo.Recibos",
                c => new
                    {
                        ReciboId = c.Int(nullable: false, identity: true),
                        Concepto = c.String(nullable: false, maxLength: 200),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaEmision = c.DateTime(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        AlumnoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReciboId)
                .ForeignKey("dbo.Alumnos", t => t.AlumnoId, cascadeDelete: true)
                .Index(t => t.AlumnoId);
            
            CreateTable(
                "dbo.AlumnosApoderados",
                c => new
                    {
                        AlumnoId = c.Int(nullable: false),
                        ApoderadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlumnoId, t.ApoderadoId })
                .ForeignKey("dbo.Alumnos", t => t.AlumnoId, cascadeDelete: true)
                .ForeignKey("dbo.Apoderados", t => t.ApoderadoId, cascadeDelete: true)
                .Index(t => t.AlumnoId)
                .Index(t => t.ApoderadoId);
            
            CreateTable(
                "dbo.AreasCurricularersAulas",
                c => new
                    {
                        AreaCurricularId = c.Int(nullable: false),
                        AulaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AreaCurricularId, t.AulaId })
                .ForeignKey("dbo.AreasCurriculares", t => t.AreaCurricularId, cascadeDelete: true)
                .ForeignKey("dbo.Aulas", t => t.AulaId, cascadeDelete: true)
                .Index(t => t.AreaCurricularId)
                .Index(t => t.AulaId);
            
            CreateTable(
                "dbo.ProfesoresCursos",
                c => new
                    {
                        ProfesorId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfesorId, t.CursoId })
                .ForeignKey("dbo.Cursos", t => t.ProfesorId, cascadeDelete: true)
                .ForeignKey("dbo.Profesores", t => t.CursoId, cascadeDelete: true)
                .Index(t => t.ProfesorId)
                .Index(t => t.CursoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recibos", "AlumnoId", "dbo.Alumnos");
            DropForeignKey("dbo.Alumnos", "NivelId", "dbo.Niveles");
            DropForeignKey("dbo.Alumnos", "GradoId", "dbo.Grados");
            DropForeignKey("dbo.Profesores", "DireccionId", "dbo.Direcciones");
            DropForeignKey("dbo.ProfesoresCursos", "CursoId", "dbo.Profesores");
            DropForeignKey("dbo.ProfesoresCursos", "ProfesorId", "dbo.Cursos");
            DropForeignKey("dbo.Notas", "EvaluacionId", "dbo.Evaluaciones");
            DropForeignKey("dbo.Evaluaciones", "TipoEvaluacionId", "dbo.TiposEvaluaciones");
            DropForeignKey("dbo.Notas", "CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Notas", "AlumnoId", "dbo.Alumnos");
            DropForeignKey("dbo.Cursos", "AreaCurricularId", "dbo.AreasCurriculares");
            DropForeignKey("dbo.AreasCurricularersAulas", "AulaId", "dbo.Aulas");
            DropForeignKey("dbo.AreasCurricularersAulas", "AreaCurricularId", "dbo.AreasCurriculares");
            DropForeignKey("dbo.Aulas", "NivelId", "dbo.Niveles");
            DropForeignKey("dbo.Matriculas", "AulaId", "dbo.Aulas");
            DropForeignKey("dbo.Matriculas", "AlumnoId", "dbo.Alumnos");
            DropForeignKey("dbo.Aulas", "GradoId", "dbo.Grados");
            DropForeignKey("dbo.Horarios", "GradoId", "dbo.Grados");
            DropForeignKey("dbo.Sesiones", "HorarioId", "dbo.Horarios");
            DropForeignKey("dbo.Sesiones", "ProfesorId", "dbo.Profesores");
            DropForeignKey("dbo.Sesiones", "CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Sesiones", "AulaId", "dbo.Aulas");
            DropForeignKey("dbo.Horarios", "NivelId", "dbo.Niveles");
            DropForeignKey("dbo.Direcciones", "DistritoId", "dbo.Distritos");
            DropForeignKey("dbo.Alumnos", "DireccionId", "dbo.Direcciones");
            DropForeignKey("dbo.Asistencias", "AlumnoId", "dbo.Alumnos");
            DropForeignKey("dbo.AlumnosApoderados", "ApoderadoId", "dbo.Apoderados");
            DropForeignKey("dbo.AlumnosApoderados", "AlumnoId", "dbo.Alumnos");
            DropIndex("dbo.ProfesoresCursos", new[] { "CursoId" });
            DropIndex("dbo.ProfesoresCursos", new[] { "ProfesorId" });
            DropIndex("dbo.AreasCurricularersAulas", new[] { "AulaId" });
            DropIndex("dbo.AreasCurricularersAulas", new[] { "AreaCurricularId" });
            DropIndex("dbo.AlumnosApoderados", new[] { "ApoderadoId" });
            DropIndex("dbo.AlumnosApoderados", new[] { "AlumnoId" });
            DropIndex("dbo.Recibos", new[] { "AlumnoId" });
            DropIndex("dbo.Evaluaciones", new[] { "TipoEvaluacionId" });
            DropIndex("dbo.Notas", new[] { "EvaluacionId" });
            DropIndex("dbo.Notas", new[] { "CursoId" });
            DropIndex("dbo.Notas", new[] { "AlumnoId" });
            DropIndex("dbo.Matriculas", new[] { "AulaId" });
            DropIndex("dbo.Matriculas", new[] { "AlumnoId" });
            DropIndex("dbo.Sesiones", new[] { "HorarioId" });
            DropIndex("dbo.Sesiones", new[] { "AulaId" });
            DropIndex("dbo.Sesiones", new[] { "ProfesorId" });
            DropIndex("dbo.Sesiones", new[] { "CursoId" });
            DropIndex("dbo.Horarios", new[] { "NivelId" });
            DropIndex("dbo.Horarios", new[] { "GradoId" });
            DropIndex("dbo.Aulas", new[] { "NivelId" });
            DropIndex("dbo.Aulas", new[] { "GradoId" });
            DropIndex("dbo.Cursos", new[] { "AreaCurricularId" });
            DropIndex("dbo.Profesores", new[] { "DireccionId" });
            DropIndex("dbo.Direcciones", new[] { "DistritoId" });
            DropIndex("dbo.Asistencias", new[] { "AlumnoId" });
            DropIndex("dbo.Alumnos", new[] { "GradoId" });
            DropIndex("dbo.Alumnos", new[] { "NivelId" });
            DropIndex("dbo.Alumnos", new[] { "DireccionId" });
            DropTable("dbo.ProfesoresCursos");
            DropTable("dbo.AreasCurricularersAulas");
            DropTable("dbo.AlumnosApoderados");
            DropTable("dbo.Recibos");
            DropTable("dbo.TiposEvaluaciones");
            DropTable("dbo.Evaluaciones");
            DropTable("dbo.Notas");
            DropTable("dbo.Matriculas");
            DropTable("dbo.Sesiones");
            DropTable("dbo.Niveles");
            DropTable("dbo.Horarios");
            DropTable("dbo.Grados");
            DropTable("dbo.Aulas");
            DropTable("dbo.AreasCurriculares");
            DropTable("dbo.Cursos");
            DropTable("dbo.Profesores");
            DropTable("dbo.Distritos");
            DropTable("dbo.Direcciones");
            DropTable("dbo.Asistencias");
            DropTable("dbo.Apoderados");
            DropTable("dbo.Alumnos");
        }
    }
}
