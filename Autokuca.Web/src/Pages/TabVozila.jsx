import React, { useState, useEffect } from "react";
import { TreeTable } from "primereact/treetable";
import { Column } from "primereact/column";

// Kreiraj komponentu TabVozila
const TabVozila = () => {
  // Definiši state za podatke, učitavanje i greške
  const [vozila, setVozila] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  // const [nodes, setNodes] = useState([]);

  // Koristi useEffect za dohvaćanje podataka prilikom montiranja komponente
  useEffect(() => {
    // Funkcija za dohvaćanje podataka
    const fetchData = async () => {
      try {
        let data;
        const response = await fetch("http://localhost:5089/api/vozila", {
          method: "GET", // or 'PUT'
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        });
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        const result = await response.json();
        console.log("Success:", result);

        // Transform data to hierarchical structure expected by TreeTable
        const formattedResult = result.map((vozilo, index) => ({
          key: vozilo.idVozilo || index,
          data: vozilo, // Ensure data is  nested
        }));

        setVozila(formattedResult);
        // setVozila(result); // Postavi podatke
      } catch (error) {
        setError(error); // Postavi grešku
      } finally {
        setLoading(false); // Postavi učitavanje na false
      }
    };

    fetchData();
  }, []); // Prazan niz znači da će se useEffect pokrenuti samo jednom, nakon montiranja

  // Prikaži učitavanje, grešku ili podatke
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  return (
    <div className="card">
      <TreeTable
        value={vozila}
        tableStyle={{ minWidth: "50rem", width: "auto" }}
        stateKey={"tree-table-state-demo-session"}
        stateStorage={"session"}
        paginator
        rows={5}
        rowsPerPageOptions={[5, 10, 25]}
        resizableColumns
        showGridlines
        columnResizeMode="expand"
      >
        <Column
          field="idVozilo"
          header="ID vozila"
          filter
          filterPlaceholder="Filter  ID"
          expander
          sortable
        ></Column>

        <Column
          field="tipVozila"
          header="Tip vozila"
          filter
          sortable
          filterPlaceholder="Tip vozila"
        ></Column>

        <Column
          field="proizvodac"
          header="Proizvođač"
          sortable
          filter
          filterPlaceholder="Proizvođač"
        ></Column>

        <Column
          field="godProizvodnje"
          sortable
          header="Godina proizvodnje"
          filter
          filterPlaceholder="Godina proizvodnje"
        ></Column>

        <Column
          field="oznakaVozila"
          header="VIN"
          filter
          sortable
          filterPlaceholder="VIN"
        ></Column>

        <Column
          field="snagaMotora"
          header="Snaga motora"
          filter
          sortable
          filterPlaceholder="Snaga motora"
        ></Column>

        <Column
          field="modelVozila"
          header="Model"
          filter
          sortable
          filterPlaceholder="Model"
        ></Column>

        <Column
          field="cijena"
          header="Cijena (euro)"
          sortable
          filter
          filterPlaceholder="Cijena"
        ></Column>
        <Column
          field="vrstaVozila"
          header="Vrsta vozila"
          filter
          sortable
          filterPlaceholder="Vrsta vozila"
        ></Column>
        <Column
          field="mjenjac"
          header="Mjenjač"
          sortable
          filter
          filterPlaceholder="Mjenjač"
        ></Column>
        <Column
          field="gorivo"
          header="Gorivo"
          filter
          sortable
          filterPlaceholder="Gorivo"
        ></Column>
      </TreeTable>
    </div>
  );
};

export default TabVozila;
