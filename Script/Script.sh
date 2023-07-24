#!/bin/bash
read -p "Ingrese el Comando que quiere ejecutar a continuación: " variable 
case $variable in
    run)
        cd ..
        dotnet watch run --project MoogleServer 
        ;;
    slides)
        cd ..
	cd Presentación
	pdflatex Presentacion.tex
        ;;
    report)
      	cd ..
	cd Informe
	pdflatex Informe.tex 
        ;;
    show_report)
        cd ..
        cd Informe 
        pdflatex Informe.tex 
	xdg-open Informe.pdf
        ;;
    show_slides)
        cd ..
        cd Presentación
        pdflatex Presentacion.tex
	xdg-open Presentacion.pdf
        ;;
    clean)
        cd ..
	cd Informe 
	rm *.log *.fls *.aux *.gz *.nav *.out *.snm *.toc *.fdb_latexmk *.gz *.syntec *.pdf
	cd ..
	cd Presentación
	rm *.log *.fls *.aux *.gz *.nav *.out *.snm *.toc *.fdb_latexmk *.gz *.syntec *.pdf
	;;
    *)
        echo "Lo sentimos, este comando no se encuentra en  nuestra lista"
        ;;
esac
