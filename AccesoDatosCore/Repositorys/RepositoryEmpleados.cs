using AccesoDatosCore.Models;
using System.Data.SqlClient;

namespace AccesoDatosCore.Repositorys
{
    public class RepositoryEmpleados
    {
        string connectionString;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryEmpleados(string cadenaConexion)
        {
            this.connectionString = cadenaConexion;
            this.cn = new SqlConnection(this.connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }
        public List<Empleado> GetEmpleados()
        {
            string sql = "SELECT * FROM EMP";
            this.com.CommandText = sql;
            List<Empleado> empleados = new List<Empleado>();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Empleado emp = new Empleado();
                emp.IdEmpleado = int.Parse(this.reader["EMP_NO"].ToString());
                emp.Apellido = this.reader["APELLIDO"].ToString();
                emp.Oficio = this.reader["OFICIO"].ToString();
                emp.Salario = int.Parse(this.reader["SALARIO"].ToString());
                empleados.Add(emp);
            }
            this.reader.Close();
            this.cn.Close();
            return empleados;
        }
        public List<Empleado> GetEmpleadosSalario(int salario)
        {
            string sql = "SELECT * FROM EMP WHERE SALARIO >@SALARIO";
            List<Empleado> empleados = new List<Empleado>();
            SqlParameter pamsalario = new SqlParameter("@SALARIO", salario);
            this.com.Parameters.Add(pamsalario);
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Empleado emp = new Empleado();
                emp.IdEmpleado = int.Parse(this.reader["EMP_NO"].ToString());
                emp.Apellido = this.reader["APELLIDO"].ToString();
                emp.Oficio = this.reader["OFICIO"].ToString();
                emp.Salario = int.Parse(this.reader["SALARIO"].ToString());
                empleados.Add(emp);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return empleados;
        }
        public Empleado FindEmpleado(int idempleado)
        {
            string sql = "SELECT * FROM EMP WHERE EMP_NO=@IDEMPLEADO";
            SqlParameter pamid = new SqlParameter("@IDEMPLEADO", idempleado);
            this.com.Parameters.Add(pamid);
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Read();
            Empleado emp = new Empleado();
            emp.IdEmpleado = int.Parse(this.reader["EMP_NO"].ToString());
            emp.Apellido = this.reader["APELLIDO"].ToString();
            emp.Oficio = this.reader["OFICIO"].ToString();
            emp.Salario = int.Parse(this.reader["SALARIO"].ToString());
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return emp;
        }
        public void IncrementarSalarioEmpleado(int idempleado, int incremento)
        {
            string sql = "UPDATE EMP SET SALARIO =SALARIO + @INCREMENTO WHERE EMP_NO=@IDEMPLEADO";
            SqlParameter pamincremento = new SqlParameter("@INCREMENTO", incremento);
            SqlParameter pamid = new SqlParameter("@IDEMPLEADO", idempleado);
            this.com.Parameters.Add(pamincremento);
            this.com.Parameters.Add(pamid);
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();

        }


    }
}
