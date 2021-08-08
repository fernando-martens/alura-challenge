import React from 'react';
import Container from './components/Container';
import Categories  from './components/Categories';
import { Title } from './components/Title'

function App() {
  return (
    <Container>
      <Title>Categorias</Title>
      <Categories />
    </Container>
  );
}

export default App;
