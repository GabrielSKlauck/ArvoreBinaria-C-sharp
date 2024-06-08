using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    public class No
    {
        private int _Valor { get; set; }          

        private No? _FilhoEsq { get; set; }

        private No? _FilhoDir { get; set; }

        public No(int valor, No? filhoEsq = null, No? filhoDir =null)
        {
            this._Valor = valor;
            this._FilhoEsq = filhoEsq;
            this._FilhoDir = filhoDir;
        }

        public void setFilhoEsq(No esq)
        {
            this._FilhoEsq = esq;
        }

        public void setFilhoDir(No dir)
        {
            this._FilhoDir = dir;
        }

        public No getFilhoEsq()
        {
            return this._FilhoEsq;
        }

        public No getFilhoDir()
        {
            return this._FilhoDir;
        }

        public int getValor()
        {
            return this._Valor;
        }
      
        public bool temFilhoEsq()
        {
            if( this._FilhoEsq == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool temFilhoDir()
        {
            if( this._FilhoDir == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ehFolha()
        {
            if(this._FilhoEsq == null && this._FilhoDir == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
