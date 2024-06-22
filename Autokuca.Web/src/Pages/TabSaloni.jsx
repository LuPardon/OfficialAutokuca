import React, { useState, useEffect } from "react";
import { TreeTable } from "primereact/treetable";
import { Column } from "primereact/column";

// Kreiraj komponentu TabSaloni
const TabSaloni = () => {
  // Definiši state za podatke, učitavanje i greške
  const [saloni, setSaloni] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  // const [nodes, setNodes] = useState([]);

  // Koristi useEffect za dohvaćanje podataka prilikom montiranja komponente
  useEffect(() => {
    // Funkcija za dohvaćanje podataka
    const fetchData = async () => {
      try {
        let data;
        const response = await fetch("http://localhost:5089/api/saloni", {
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
        const formattedResult = result.map((salon, index) => ({
          key: salon.idSalona || index,
          data: salon, // Ensure data is  nested
        }));

        setSaloni(formattedResult);
        // setSaloni(result); // Postavi podatke
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
        value={saloni}
        tableStyle={{ minWidth: "80rem" }}
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
          field="idSalona"
          header="ID salona"
          expander
          filter
          filterPlaceholder="Filter by ID"
          sortable
        ></Column>

        <Column
          field="nazivSalona"
          header="Naziv salona"
          filter
          filterPlaceholder="Filter by name"
          sortable
        ></Column>
      </TreeTable>
    </div>
  );
};

export default TabSaloni;
