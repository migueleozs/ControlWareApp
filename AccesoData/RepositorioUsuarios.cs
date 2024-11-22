using Entidades;
using Presentacion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AccesoData
{
    public class RepositorioUsuarios : IRepositorio<Usuario>
    {
        private string filePath;
        public XmlTextWriter archivoxml;
        private XDocument xmlDocument;


        //private string xmlFilePath = "backup.xml";



        public RepositorioUsuarios(string nameFile)
        {
            try
            {
                this.filePath = nameFile;
                if (!File.Exists(filePath))
                {
                    CrearArchivoInicial();
                }
                xmlDocument = XDocument.Load(filePath);

                //xmlDoc = new XmlDocument();
                //xmlDoc.Load("Usuarios.xml");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CrearArchivoInicial()
        {
            XDocument nuevoDocumento = new XDocument(new XElement("Usuarios"));
            nuevoDocumento.Save(filePath);

        }

        public void CrearUsuario(Usuario usuario)
        {
            usuario.Id = ObtenerUltimoIdUsuario();
            string passEncriptada = Encriptacion.EncriptarClave(usuario.Password);
            XElement nuevoUsuario = new XElement("Usuario",
                new XElement("Id", usuario.Id),
                new XElement("Nombre", usuario.Nombre),
                new XElement("Password", passEncriptada),
                new XElement("Rol", new XElement("nombre",usuario.rol.ObtenerNombre()),
                usuario.rol._permisos.Select(per => 
                new XElement( "Permiso" ,
                    new XElement("Nombre", per.ObtenerNombre()) , 
                    new XElement ("Acceso", per.TieneAcceso()) )
                ))
                );
            xmlDocument.Root.Add(nuevoUsuario);
            xmlDocument.Save(filePath);
        }

        public List<Usuario> MostrarUsuarios()
        {
            List<Usuario> _usuariosLista = new List<Usuario>();
            _usuariosLista = xmlDocument.Descendants("Usuario").Select(usuario => new Usuario
            {
                Id = int.Parse(usuario.Element("Id").Value),
                Nombre = usuario.Element("Nombre").Value,
                Password = usuario.Element("Password").Value,
                _rol = usuario.Element("Rol").Element("nombre").Value
            }).ToList();

            return _usuariosLista;
        }

        public void ModificarUsuario(int idUsuario, string nuevoNombre, string nuevoRol)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("Usuarios.xml");

                // Buscar el nodo del usuario con el ID correspondiente
                XmlNode usuarioNode = xmlDoc.SelectSingleNode($"/Usuarios/Usuario[Id='{idUsuario}']");

                if (usuarioNode != null)
                {
                    // Modificar los valores del usuario
                    XmlNode nombreNode = usuarioNode.SelectSingleNode("Nombre");
                    if (nombreNode != null)
                    {
                        nombreNode.InnerText = nuevoNombre;
                    }

                    XmlNode rolNode = usuarioNode.SelectSingleNode("Rol");
                    if (rolNode != null)
                    {
                        //rolNode.SelectNodes().ToString();
                        rolNode.InnerText = nuevoRol;
                    }

                    // Guardar el archivo XML actualizado
                    xmlDoc.Save("Usuarios.xml");

                    MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public Usuario BuscarUsuario(string usuarioIngresado)
        {
            try
            {
                
                var cualquiera = xmlDocument.Descendants("Usuario").FirstOrDefault(x => x.Element("Nombre").Value == usuarioIngresado);
                if (cualquiera != null)
                {
                    Usuario usuarioEncontrado = new Usuario(int.Parse(cualquiera.Element("Id").Value), cualquiera.Element("Rol").Element("nombre").Value, cualquiera.Element("Nombre").Value, cualquiera.Element("Password").Value);
                    Rol rolito = new Rol(cualquiera.Element("Rol").Element("nombre").Value);
                    
                    List<Permiso> permisos = cualquiera.Descendants("Permiso")
                        .Select(element => new Permiso
                        (
                            element.Element("Nombre").Value,
                            bool.Parse(element.Element("Acceso").Value)
                        ))
                        .ToList();
                    permisos.ForEach(permiso =>
                    {
                        rolito.AgregarPermiso(permiso);
                    });
                    usuarioEncontrado.rol = rolito;
                    return usuarioEncontrado;
                }
                else
                {
                    throw new ArgumentException("Error: El nombre de usuario no puede estar vacío.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }


        public void EliminarUsuario(Usuario usuario)
        {
            // Ruta del archivo XML
            string rutaArchivo = "Usuarios.xml";

            // Crear un objeto XmlDocument y cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(rutaArchivo);

            

            string xpath = $"/Usuarios/Usuario[Id='{usuario.Id}']";
            XmlNode nodoUsuario = xmlDoc.SelectSingleNode(xpath);

            if (nodoUsuario != null)
            {
                // Obtener el nodo padre del usuario y eliminar el nodo del usuario
                nodoUsuario.ParentNode.RemoveChild(nodoUsuario);

                // Guardar los cambios en el archivo XML
                xmlDoc.Save(rutaArchivo);

                Console.WriteLine("Usuario eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }

        
        public void ModificarPermisos(Usuario usuario, List<Permiso> items)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("Usuarios.xml");

                // Buscar el nodo del usuario con el ID correspondiente
                XmlNode usuarioNode = xmlDoc.SelectSingleNode($"/Usuarios/Usuario[Id='{usuario.Id}']");

                if (usuarioNode != null)
                {
                    XmlNode rolNode = usuarioNode.SelectSingleNode("Rol");
                    if (rolNode != null)
                    {
                        string nombreRol = rolNode.SelectSingleNode("nombre").InnerText;
                        // Eliminar todos los nodos existentes bajo <Rol>
                        rolNode.RemoveAll();
                        XmlElement nombreRolElement = xmlDoc.CreateElement("nombre");
                        nombreRolElement.InnerText = nombreRol;
                        rolNode.AppendChild(nombreRolElement);
                        // Agregar los nuevos nodos desde items
                        foreach (var nuevoPermiso in items)
                        {
                            XmlElement permisoElement = xmlDoc.CreateElement("Permiso");
                            XmlElement nombreElement = xmlDoc.CreateElement("Nombre");
                            nombreElement.InnerText = nuevoPermiso.ObtenerNombre();
                            XmlElement accesoElement = xmlDoc.CreateElement("Acceso");
                            accesoElement.InnerText = nuevoPermiso.TieneAcceso().ToString();

                            permisoElement.AppendChild(nombreElement);
                            permisoElement.AppendChild(accesoElement);

                            rolNode.AppendChild(permisoElement);
                        }
                        Rol nuevoRol = new Rol(nombreRol, items);
                        usuario.rol = nuevoRol;
                    }

                    // Guardar el archivo XML actualizado
                    xmlDoc.Save("Usuarios.xml");

                    

                    MessageBox.Show("Permisos modificados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Permiso> ObtenerPermisosUsuario(int userId)
        {
            List<Permiso> permisos = new List<Permiso>();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("Usuarios.xml");

                // Buscar el nodo del usuario con el ID correspondiente
                XmlNode usuarioNode = xmlDoc.SelectSingleNode($"/Usuarios/Usuario[Id='{userId}']");

                if (usuarioNode != null)
                {
                    XmlNode rolNode = usuarioNode.SelectSingleNode("Rol");

                    if (rolNode != null)
                    {
                        XmlNodeList permisosNodes = rolNode.SelectNodes("Permiso");

                        foreach (XmlNode permisoNode in permisosNodes)
                        {
                            string nombre = permisoNode.SelectSingleNode("Nombre")?.InnerText;
                            bool acceso = bool.Parse(permisoNode.SelectSingleNode("Acceso")?.InnerText ?? "false");

                            permisos.Add(new Permiso (nombre, acceso));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los permisos del usuario: {ex.Message}");
            }

            return permisos;
        }


        public int ObtenerUltimoIdUsuario()
        {
            var listaUsuarios = MostrarUsuarios().ToList();
            // Verifica si la lista de clientes está vacía
            if (listaUsuarios.Count == 0)
            {
                // Si la lista está vacía, devuelve 1 como nuevo ID
                return 1;
            }
            else
            {
                // Si la lista no está vacía, obtén el ID del último cliente y suma 1
                return listaUsuarios.Max(c => c.Id) + 1;
            }
        }


        //BACKUP

        public void RealizarBackup(string archivoOriginal, string archivoBackup)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(archivoOriginal))
                {
                    using (XmlWriter writer = XmlWriter.Create(archivoBackup))
                    {
                        writer.WriteNode(reader, true);
                    }
                }

                Console.WriteLine("Backup realizado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al realizar el backup: " + ex.Message);
            }
        }

        public void RealizarRestore(string archivoBackup, string archivoBD)
        {
            try
            {
                // Crear un lector XML para el archivo de backup
                using (XmlReader reader = XmlReader.Create(archivoBackup))
                {
                    // Crear un escritor XML para el archivo restaurado
                    using (XmlWriter writer = XmlWriter.Create(archivoBD))
                    {
                        // Copiar el contenido desde el lector al escritor
                        writer.WriteNode(reader, true);
                    }
                }

                Console.WriteLine("Restore realizado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al realizar el restore: " + ex.Message);
            }

        }


        public void addItems()
        {
            throw new NotImplementedException();
        }

        public void getItems()
        {
            throw new NotImplementedException();
        }

        public void removeItems()
        {
            throw new NotImplementedException();
        }

        public void updateItems()
        {
            throw new NotImplementedException();
        }

    }
}
