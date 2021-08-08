import React, { useEffect, useState } from "react";
import styled from "styled-components";
import api from "../../services/api";
import { ICategories } from "./interface";

export const Wrapper = styled.div`
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  align-items: center;
  justify-content: center;
`

 const Blocks = styled.div`
  width: 100%;
  max-width: 250px;
  height: 200px;
  margin: 0.5rem;
  background-color: #d3d3d3;
  border-radius: 8px;
`

const Categories = () =>{
  const [categories, setCategories] = useState<ICategories[]>([]);
  useEffect(() => {
    api
      .get("/categorias")
      .then((response) => setCategories(response.data))
      .catch((err) => {
        console.error("ops! ocorreu um erro" + err);
      });
  }, []);
  
  return (
    <Wrapper>
      {categories.map((category)=>{
        return (
          <Blocks key={category.id}>
            {category.titulo}
          </Blocks>
        )
      })}
    </Wrapper>
  )
}

export default Categories;