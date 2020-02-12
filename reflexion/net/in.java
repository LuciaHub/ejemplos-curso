import java.util.ArrayList;

class Pelicula extends Contenido implements IReproducible {

    @Override
    public void iniciar() {
        // TODO Auto-generated method stub

    }

    @Override
    public void pausar() {
        // TODO Auto-generated method stub

    }

    @Override
    public void adelantar() {
        // TODO Auto-generated method stub

    }

    @Override
    public void retroceder() {
        // TODO Auto-generated method stub

    }

}

class Serie extends Contenido {
    private ArrayList<Capitulo> capitulos = new ArrayList<Capitulo>();
}

class Capitulo implements IReproducible {

    @Override
    public void iniciar() {
        // TODO Auto-generated method stub

    }

    @Override
    public void pausar() {
        // TODO Auto-generated method stub

    }

    @Override
    public void adelantar() {
        // TODO Auto-generated method stub

    }

    @Override
    public void retroceder() {
        // TODO Auto-generated method stub

    }

}

abstract class Contenido {

}

interface IReproducible {
    public void iniciar();
    public void pausar();
    public void adelantar();
    public void retroceder();
}