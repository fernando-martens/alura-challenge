import styled from 'styled-components';

const Container = styled.div`
  padding-right: 15px;
  padding-left: 15px;
  margin-right: auto;
  margin-left: auto;
  @media (min-width: sm-device){
    max-width: 720px
  }
  @media (min-width: md-device){
    max-width: 720px
  }
  @media (min-width: lg-device){
    max-width: 960px 
  }
  @media (min-width: xl-device){
    max-width: 1170px
  }
`

export default Container;