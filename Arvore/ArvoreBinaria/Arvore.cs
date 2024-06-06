﻿using System;
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

        public void delete(int valor)
        {
            No noRemocao = buscaNo(valor);
            No noPai = buscaPai(valor);

            //CASO NO SEJA FOLHA
            if (noRemocao.ehFolha())
            {               
                if(noPai.getFilhoEsq().getValor() == valor)
                {
                    noPai.setFilhoEsq(null);
                }else if (noPai.getFilhoDir().getValor() == valor)
                {
                    noPai.setFilhoDir(null);
                }          
            }
            //CASO NO TENHA SOMENTE UM FILHO
            if (noRemocao.temFilhoEsq() && !noRemocao.temFilhoDir())
            {
                noPai.setFilhoDir(noRemocao.getFilhoEsq());
            }
            else if (noRemocao.temFilhoDir() && !noRemocao.temFilhoEsq())
            {
                noPai.setFilhoEsq(noRemocao.getFilhoDir());
            }

            //CASO NO TENHA DOIS FILHOS
            if (noRemocao.temFilhoDir() && noRemocao.temFilhoEsq())
            {
                //AO BUSCA O NO SUCESSOR, PASSAR NO A DIREITA DO QUE ESTA PARA REMOCAO
                No novoNo = buscaSucessor(valor, noRemocao.getFilhoDir());
                
            }
        }

        private No buscaSucessor(int valor, No noAtual)
        {
            if (noAtual.temFilhoEsq())
            {
                No aux = noAtual.getFilhoEsq();
                noAtual.setFilhoEsq(aux.getFilhoDir());
                return aux;
            }
            if (noAtual.temFilhoDir())
            {
                buscaSucessor(valor, noAtual.getFilhoDir());
            }
            return null;
        }

        public No buscaNo(int valor, No? noAtual = null)
        {
            if (noAtual == null)
            {
                noAtual = _Raiz;
            }
            if (noAtual.getValor() == valor)
            {
                return noAtual;
            }
            if (valor <= noAtual.getValor())
            {
                return buscaNo(valor, noAtual.getFilhoEsq());
            }
            if (valor > noAtual.getValor())
            {
                return buscaNo(valor, noAtual.getFilhoDir());
            }
            return null;
        }

        private No buscaPai(int valor, No? noAtual = null)
        {
            if (noAtual == null)
            {
                noAtual = _Raiz;
            }
            if (valor <= noAtual.getValor())
            {
                if (noAtual.getFilhoEsq().getValor() == valor)
                {
                    return noAtual;
                }
                else
                {
                    return buscaPai(valor, noAtual.getFilhoEsq());
                }
            }
            if(valor > noAtual.getValor())
            {
                if(noAtual.getFilhoDir().getValor() == valor)
                {
                    return noAtual;
                }
                else
                {
                   return buscaPai(valor, noAtual.getFilhoDir());
                }
            }
            return null;
        }
    }
}
