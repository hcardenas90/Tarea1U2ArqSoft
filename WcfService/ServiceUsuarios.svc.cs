using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuarios" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceUsuarios.svc o ServiceUsuarios.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceUsuarios : IServiceUsuarios
    {
        public bool create(Usuarios usuario)
        {
            using (pruebaEntities mde = new pruebaEntities())
            {
                try
                {
                    UsuariosEntity pe = new UsuariosEntity();
                    pe.Nombre = usuario.Nombre;
                    pe.FechaNacimento = usuario.FechaNacimento;
                    pe.Sexo = usuario.Sexo;
                    mde.Usuarios.Add(pe);
                    mde.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            };
        }

        public bool delete(Usuarios usuario)
        {
            using (pruebaEntities mde = new pruebaEntities())
            {
                try
                {
                    UsuariosEntity pe = mde.Usuarios.Single(p => p.IdUsuario == usuario.IdUsuario);
                    mde.Usuarios.Remove(pe);
                    mde.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            };
        }

        public bool edit(Usuarios usuario)
        {
            using (pruebaEntities mde = new pruebaEntities())
            {
                try
                {
                    UsuariosEntity pe = mde.Usuarios.Single(p => p.IdUsuario == usuario.IdUsuario);
                    pe.Nombre = usuario.Nombre;
                    pe.FechaNacimento = usuario.FechaNacimento;
                    pe.Sexo = usuario.Sexo;
                    mde.SaveChanges();
                    
                    return true;
                }
                catch
                {
                    return false;
                }
            };
        }

        public Usuarios find(string id)
        {
            using (pruebaEntities mde = new pruebaEntities())
            {
                int ID = Convert.ToInt32(id);
                return mde.Usuarios.Where(pe=> pe.IdUsuario == ID).Select(pe => new Usuarios
                {
                    IdUsuario = pe.IdUsuario,
                    Nombre = pe.Nombre,
                    FechaNacimento = pe.FechaNacimento,
                    Sexo = pe.Sexo
                }).First();
            };
        }

        public List<Usuarios> findall()
        {
            using(pruebaEntities mde = new pruebaEntities())
            {
                return mde.Usuarios.Select(pe => new Usuarios {
                    IdUsuario= pe.IdUsuario,
                    Nombre= pe.Nombre,
                    FechaNacimento= pe.FechaNacimento,
                    Sexo= pe.Sexo
                }).ToList();
            };
        }
    }
}
