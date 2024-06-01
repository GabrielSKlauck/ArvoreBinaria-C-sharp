using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    public class Arvore
    {
        private No _Raiz;

        public Arvore(int valor)
        {
            _Raiz = new No(valor);
        }

        public void addItem(int valor, No? noAtual = null)
        {
            if (noAtual == null)
            {
                noAtual = _Raiz;
            }
            if (valor > noAtual.getValor())
            {
                if (!noAtual.temFilhoDir())
                {
                    No novoFilhoDir = new No(valor);
                    noAtual.setFilhoDir(novoFilhoDir);
                }
                else
                {
                    addItem(valor, noAtual.getFilhoDir());
                }
                

            }

            if (valor <= noAtual.getValor())
            {
                if(!noAtual.temFilhoEsq())
                {
                    No novoFilhoEsq = new No(valor);
                    noAtual.setFilhoEsq(novoFilhoEsq);
                }
                else
                {
                    addItem(valor, noAtual.getFilhoEsq());
                }

                
            }
        }

        public bool valorExiste(int valor, No? noAtual = null)
        {
            if(noAtual == null)
            {
                noAtual = _Raiz;
            }
            if (noAtual.getValor() == valor)
            {
                return true;
            }
            if (valor <= noAtual.getValor())
            {
                return valorExiste(valor, noAtual.getFilhoEsq());
            }
            if(valor > noAtual.getValor())
            {
                return valorExiste(valor, noAtual.getFilhoDir());                                     
            }
            return false;
        }

        public String preOrdem(No? noAtual = null)
        {
            String itens = "";
            if(noAtual == null)
            {
                noAtual = _Raiz;
            }
            itens = itens + noAtual.getValor() + "-";
            if (noAtual.temFilhoEsq())
            {
                itens = itens + preOrdem(noAtual.getFilhoEsq());
            }
            if (noAtual.temFilhoDir())
            {
                itens = itens + preOrdem(noAtual.getFilhoDir());
            }

            return itens;
        }

        public String emOrdem(No? noAtual = null)
        {
            String itens = "";
            if (noAtual == null)
            {
                noAtual = _Raiz;
            }

            if (noAtual.temFilhoEsq())
            {
                itens += emOrdem(noAtual.getFilhoEsq());
            }
            itens = itens + noAtual.getValor() + "-";
            if (noAtual.temFilhoDir())
            {
                itens += emOrdem(noAtual.getFilhoDir());
            }
            return itens;
        }

        public String posOrdem(No? noAtual = null)
        {
            String itens = "";
            if(noAtual == null)
            {
                noAtual= _Raiz;
            }
            if (noAtual.temFilhoEsq())
            {
                itens += posOrdem(noAtual.getFilhoEsq());
            }
            if (noAtual.temFilhoDir())
            {
                itens += posOrdem(noAtual.getFilhoDir());
            }
            itens = itens + noAtual.getValor() + "-";
            return itens;
        }
    }
}
