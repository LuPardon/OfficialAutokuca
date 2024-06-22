import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { Link } from "react-router-dom";

export default function KarticaVozilo({ vozilo }) {
  const header = (
    <img
      alt="slika vozila"
      //   src={vozilo.slikaVozila}
      src="https://www.autohrvatska.hr/EasyEdit/UserFiles/SliderImages/novi-peugeot-208/novi-peugeot-208-638482147470155587_1600_700.jpeg"
    />
  );
  const footer = (
    <>
      <Button label="Save" icon="pi pi-check" />
      <Button
        label="Cancel"
        severity="secondary"
        icon="pi pi-times"
        style={{ marginLeft: "0.5em" }}
      />
    </>
  );

  const title = `${vozilo.tipVozila} ${vozilo.proizvodac} - ${vozilo.modelVozila}, ${vozilo.godProizvodnje} ${vozilo.cijena} €`;
  const subTitle = `${vozilo.snagaMotora} ${vozilo.vrstaVozila}`;
  return (
    <Link
      to={"/sva_vozila/" + vozilo.idVozilo}
      vozilo={vozilo}
      className="flex justify-center items-center"
      style={{ padding: "1rem", textDecoration: "none" }}
    >
      <Card
        title={title}
        subTitle={subTitle}
        header={header}
        className="md:w-25rem w-full sm:w-30rem"
        style={{ maxWidth: "25rem", margin: "auto" }}
      >
        <p className="m-0">ovdje ide moj opis vozila iz baze</p>
      </Card>
    </Link>
  );
}
