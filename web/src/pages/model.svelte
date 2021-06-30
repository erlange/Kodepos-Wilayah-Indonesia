<script lang="ts" context="module">

  export interface IWilayah {
    id: string;
    prop: string;
    kabu: string;
    keca: string;
    desa: string;
    kode: string;
  }

  export class Wilayah implements IWilayah {
    public id: string;
    public prop: string;
    public kabu: string;
    public keca: string;
    public desa: string;
    public kode: string;


    public constructor(id: string, prop: string, kabu: string, keca: string, desa: string, kode: string)  {
      id;
      prop;
      kabu;
      keca;
      desa;
      kode;
    }

  }

</script>