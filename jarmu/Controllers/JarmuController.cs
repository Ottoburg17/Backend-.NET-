using Microsoft.AspNetCore.Mvc;
using jarmu;

namespace jarmu.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JarmuController : ControllerBase
{

    private readonly DataService _db;
    public JarmuController(DataService db)
    {
        _db = db;
    }

    [HttpGet(Name = "GetJarmu")]
    public IEnumerable<Jarmu> Get()
    {
        return _db.Jarmuvek.ToArray();
    }

    [HttpPost]
    public Jarmu Post(Jarmu jarmu) {
        _db.Jarmuvek.Add(jarmu);
        _db.SaveChanges();
        var res = _db.Jarmuvek.Single(e => e.Id == jarmu.Id);
        return res;
    }

    [HttpPut("{id}")]
    public Jarmu Put(long id, Jarmu jarmu) {
        var act = _db.Jarmuvek.Find(id);
        if(act == null) { return jarmu; }
        act.Rendszam = jarmu.Rendszam;
        act.Marka = jarmu.Marka;
        act.Ar = jarmu.Ar;
        _db.SaveChanges();
        var res = _db.Jarmuvek.Single(e => e.Id == id);
        return res;
    }

    [HttpDelete("{id}")]
    public int Delete(long id) {
        var act = _db.Jarmuvek.Find(id);
        if(act == null) { return 0; }
        _db.Jarmuvek.Remove(act);
        var affectedRecords = _db.SaveChanges();
        return affectedRecords;
    }    

}
