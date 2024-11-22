using AccesoData;
using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Aplication
{
    public class Negocio
    {
        private Empresa empresa = new Empresa();
        private RepositorioCliente repoCliente = new RepositorioCliente("Clientes.xml");
        private RepositorioProductos repoProducto = new RepositorioProductos("Productos.xml");
        private RepositorioVentas repoVenta = new RepositorioVentas("Ventas.xml");
        private RepositorioUsuarios _repoUsuarios = new RepositorioUsuarios("Usuarios.xml");
        private RepositorioInventario repoInventario = new RepositorioInventario("Inventarios.xml");
        Sesion sesionActual = new Sesion();
        private List<string> listaBackUps = new List<string>();


        private List<Producto> productosEnCarrito = new List<Producto>();
        public double CostoTotal = 0;

        public Negocio()
        {
        }

        public Negocio(Empresa empresa)
        {
            this.empresa = empresa;
        }

        public void RealizarVenta(Cliente cliente, List<Producto> productos)
        {
            empresa.Vender(cliente, productos);
        }

        public Sesion GetSesion()
        {
            return sesionActual;
        }

        //PRODUCTOS

        public void AgregarProducto(Producto producto, int cantidad)
        {
            repoProducto.CrearProducto(producto);

            var inventarioNuevo = new Inventario(producto, cantidad);
            repoInventario.CrearInventario(inventarioNuevo);
            //empresa.AgregarProducto(producto);
        }

        public void EliminarProducto(Producto producto)
        {
            repoProducto.EliminarProducto(producto);
        }

        public List<Producto> ListaProductos()
        {
            return repoProducto.MostrarProductos();
        }

        public List<Inventario> ListaInventario()
        {
            return new List<Inventario> (repoInventario.MostrarInventario());
        }
        public Producto BuscarProductoxId(int Id)
        {
            return repoProducto.ConsultarProductoxId(Id);
        }

        public Producto BuscarProductoxNombre(string nombre)
        {
            return repoProducto.ConsultarProductoxNombre(nombre);
        }

        public bool ExisteProductoxId(int Id)
        {
            return repoProducto.ConsultarProductoxId(Id) != null;
        }
        public bool ExisteProductoxNombre(string nombre)
        {
            return repoProducto.ConsultarProductoxNombre(nombre) != null;
        }

        //CLIENTES

        public List<Cliente> ListaClientes()
        {
            return repoCliente.MostrarClientes();
        }

        public void AgregarCliente(Cliente cliente)
        {
            repoCliente.GuardarCliente(cliente);
            //empresa.AgregarCliente(cliente);
        }

        public void EliminarCliente(Cliente clienteEscogido)
        {
            repoCliente.EliminarCliente(clienteEscogido);
        }

        public Cliente BuscarClientexDNI(int DNI)
        {
            return repoCliente.ConsultarClientexDNI(DNI);
        }

        public bool ExisteClientexDNI(int DNI)
        {
            return repoCliente.ConsultarClientexDNI(DNI) != null;
        }


        // VENTAS

        public void AgregarVenta(Venta venta)
        {
            repoVenta.GuardarVenta(venta);
        }

        public void AgregarProductoACarrito(Producto producto)
        {
            try
            {
                if (producto == null)
                {
                    Console.WriteLine("El producto es nulo.");
                    return;
                }

                productosEnCarrito.Add(producto);
                CostoTotal += producto.Precio;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error al agregar el producto al carrito: " + ex.Message);
            }
        }

        public List<Producto> ProductosEnCarrito()
        {

            return new List<Producto>(productosEnCarrito);

        }

        public List<Venta> MostrarVentas()
        {
            return new List<Venta>(repoVenta.MostrarVentas());
        }

        // SESION

        public void actualizarSesion(Sesion sesion)
        {
            sesionActual = sesion;
        }

        // USUARIOS
        public void AgregarUsuario(Usuario usuario)
        {
            _repoUsuarios.CrearUsuario(usuario);
        }

        public List<Usuario> MostrarUsuarios()
        {
            return new List<Usuario>(_repoUsuarios.MostrarUsuarios());
        }

        public List<Usuario> ListaUsuarios()
        {
            return _repoUsuarios.MostrarUsuarios();
        }

        public void ModificarUsuario(int id, string nombre, string tipo)
        {
            _repoUsuarios.ModificarUsuario(id, nombre, tipo);
        }

        public void EliminarUsuario(Usuario usuario)
        {
            _repoUsuarios.EliminarUsuario(usuario);
        }

        public Usuario BuscarUsuario(string nombre)
        {
            return _repoUsuarios.BuscarUsuario(nombre);
        }

        public void ModificarPermisos(Usuario usuario, List<int> permisosCheckedList)
        {
            List<Permiso> permisos = new List<Permiso>();
            for (int i = 0; i < 6; i++) 
            {
                bool tienePermiso = permisosCheckedList.Contains(i);
                permisos.Add(new Permiso(GetNombrePermiso(i), tienePermiso));
            }
            _repoUsuarios.ModificarPermisos(usuario, permisos);
            _repoUsuarios.MostrarUsuarios();
        }

        string GetNombrePermiso(int indice)
        {
            switch (indice)
            {
                case 0:
                    return "Clientes";
                case 1:
                    return "Venta";
                case 2:
                    return "Productos";
                case 3:
                    return "Compras";
                case 4:
                    return "Reportes";
                case 5:
                    return "Empleados";
                default:
                    return "Error";
            }
        }


        public void PermisosAdmin(Usuario usuario)
        {
            var RolAdmin = new Rol("Admin");
            var ManipularCliente = new Permiso("Clientes", true);
            var ManipularVenta = new Permiso("Venta", true);
            var ManipularProductos = new Permiso("Productos", true);
            var ManipularCompras = new Permiso("Compras", true);
            var ManipularReportes = new Permiso("Reportes", true);
            var ManipularEmpleados = new Permiso("Empleados", true);

            RolAdmin.AgregarPermiso(ManipularCliente);
            RolAdmin.AgregarPermiso(ManipularVenta);
            RolAdmin.AgregarPermiso(ManipularProductos);
            RolAdmin.AgregarPermiso(ManipularCompras);
            RolAdmin.AgregarPermiso(ManipularReportes);
            RolAdmin.AgregarPermiso(ManipularEmpleados);

            usuario.rol = RolAdmin;
        }

        public void PermisosSupervisor(Usuario usuario)
        {
            var RolSupervisor = new Rol("Supervisor");
            var ManipularCliente = new Permiso("Clientes", true);
            var ManipularVenta = new Permiso("Venta", true);
            var ManipularProductos = new Permiso("Productos", true);
            var ManipularCompras = new Permiso("Compras", true);
            var ManipularReportes = new Permiso("Reportes", false);
            var ManipularEmpleados = new Permiso("Empleados", false);

            RolSupervisor.AgregarPermiso(ManipularCliente);
            RolSupervisor.AgregarPermiso(ManipularVenta);
            RolSupervisor.AgregarPermiso(ManipularProductos);
            RolSupervisor.AgregarPermiso(ManipularCompras);
            RolSupervisor.AgregarPermiso(ManipularReportes);
            RolSupervisor.AgregarPermiso(ManipularEmpleados);

            usuario.rol = RolSupervisor;
        }

        public void PermisosCajero(Usuario usuario)
        {
            var RolCajero = new Rol("Cajero");
            var ManipularCliente = new Permiso("Clientes", true);
            var ManipularVenta = new Permiso("Venta", true);
            var ManipularProductos = new Permiso("Productos", true);
            var ManipularCompras = new Permiso("Compras", false);
            var ManipularReportes = new Permiso("Reportes", false);
            var ManipularEmpleados = new Permiso("Empleados", false);

            RolCajero.AgregarPermiso(ManipularCliente);
            RolCajero.AgregarPermiso(ManipularVenta);
            RolCajero.AgregarPermiso(ManipularProductos);
            RolCajero.AgregarPermiso(ManipularCompras);
            RolCajero.AgregarPermiso(ManipularReportes);
            RolCajero.AgregarPermiso(ManipularEmpleados);

            usuario.rol = RolCajero;
        }


        // BACKUP

        public void crearBackUp(string archivoBackup)
        {
            string xml = archivoBackup + ".xml";

            if (File.Exists(xml))
            {
                throw new IOException("Ya existe un archivo de respaldo en la ruta especificada.");
            }
            _repoUsuarios.RealizarBackup("Usuarios.xml", xml);
            
        }


        // RESTORE

        public void realizarRestore(string archivoBackup)
        {
            string xml = archivoBackup + ".xml";

            if (!File.Exists(xml))
            {
                throw new FileNotFoundException("El archivo de respaldo no existe en la ruta especificada.", xml);
            }
            _repoUsuarios.RealizarRestore(xml, "Usuarios.xml");
            
        }


    }
}
