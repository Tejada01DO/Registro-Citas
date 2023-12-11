using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public  class EmployeeBLL
{
        private Context _context;

        public EmployeeBLL(Context context)
        {
            this._context = context;
        }


        public bool Existe(int Id)
        {
            return _context.employee
                .Any(c => c.EmployeeId == Id);
        }

        public bool Guardar(Employee employee)
        {
            if (!Existe(employee.EmployeeId))
                return this.Insertar(employee);
            else
                return this.Modificar(employee);
        }


        private bool Insertar(Employee employee)
        {
            try
            {

                if(employee != null)
                {
                    if(employee.Events != null)
                    {
                        foreach(var item in employee.Events)
                        {
                            var events = _context.events.Find(item.Id);
                            if(events != null)
                            {
                                _context.events.Update(events);
                                _context.SaveChanges();
                                _context.Entry(events).State = EntityState.Detached;
                            }
                        }
                        _context.employee.Add(employee);
                        bool Guardo = _context.SaveChanges() > 0;
                        _context.Entry(employee).State = EntityState.Detached;
                        return Guardo;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                

            }
            catch
            {
                throw;
            }
            
        }

        private bool Modificar(Employee employee)
        {
            try
            {
                if(employee != null)
                {
                    var employeeAnterior = _context.employee
                    .Where(e => e.EmployeeId == employee.EmployeeId)
                    .Include(e => e.Events)
                    .AsNoTracking()
                    .SingleOrDefault();
                

                    if(employeeAnterior != null)
                    {
                        if(employeeAnterior.Events != null)
                        {
                            foreach(var item in employeeAnterior.Events)
                            {
                                var events = _context.events.Find(item.Id);
                                if(events != null)
                                {
                                    _context.events.Update(events);
                                    _context.SaveChanges();
                                    _context.Entry(events).State = EntityState.Detached;
                                }
                            }
                            
                        }
                        
                    }
                    if(employee.Events != null)
                    {
                        if(employee.Events != null)
                        {
                            foreach(var item in employee.Events)
                            {
                                var events = _context.events.Find(item.Id);
                                if(events != null)
                                {
                                    _context.events.Update(events);
                                    _context.SaveChanges();
                                    _context.Entry(events).State = EntityState.Detached;
                                }
                            }
                            
                        }
                    }
                    _context.Set<EventModel>().RemoveRange(employeeAnterior.Events);
                    _context.Set<EventModel>().AddRange(employee.Events);
                    _context.employee.Update(employee);
                    int cantidad = _context.SaveChanges();
                    _context.Entry(employee).State= EntityState.Detached;
                    return cantidad > 0;
                    
                   
                }
                else
                {
                    return false;
                }

                

            }
            catch
            {
                throw;
            }

            

            
        }
        public bool Eliminar(Employee employee)
        {
            try
            {

                if(employee != null)
                {
                    if(employee.Events != null)
                    {
                        foreach(var item in employee.Events)
                        {
                            var events = _context.events.Find(item.Id);
                            if(events != null)
                            {
                                _context.events.Update(events);
                                _context.SaveChanges();
                                _context.Entry(events).State = EntityState.Detached;
                            }
                        }
                        _context.employee.Remove(employee);
                        bool Guardo = _context.SaveChanges() > 0;
                        _context.Entry(employee).State = EntityState.Detached;
                        return Guardo;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                else
                {
                    return false;
                }

                

            }
            catch
            {
                throw;
            }
            
        }


        public Employee BuscarPorID(int EmployeeId)
        {
            return _context.employee
                .Include(c => c.Events)
                .Where(c => c.EmployeeId == EmployeeId == true)
                .AsNoTracking()
                .SingleOrDefault();
        }

        
        public List<Employee> GetList(Expression<Func<Employee, bool>> Criterio){
                return _context.employee
                    .AsNoTracking()
                    .Where(Criterio).Include(c => c.Events).ToList();
        }

        public Employee Buscar(string nombre)
        {
            return _context.employee
                .Include(c => c.Events)
                .Where(c => c.EmployeeName == nombre)
                .AsNoTracking()
                .SingleOrDefault();
        }
        

}