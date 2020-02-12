using System;

class MainClass {
  public static void Main (string[] args) {
	 Par<int,string> par = new Par<int,string>(1,"A");
	   Console.WriteLine (par.getValor());
       Console.WriteLine (par.getClave());
  }
 class Par<T, S> {
        private T _valor;
        private S _clave;

        public Par (T valor, S clave) {
            this._valor = valor;
            this._clave = clave;
        }
        public T getValor() {
            return this._valor;
        }
         public S getClave () {
            return this._clave;
        }
    }	
} 