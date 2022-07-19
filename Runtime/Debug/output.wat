(module
 (type $f64_=>_f64 (func (param f64) (result f64)))
 (type $f64_i32_=>_i32 (func (param f64 i32) (result i32)))
 (type $none_=>_none (func))
 (type $i32_i32_=>_i32 (func (param i32 i32) (result i32)))
 (type $f64_i32_=>_f64 (func (param f64 i32) (result f64)))
 (type $f64_f64_=>_f64 (func (param f64 f64) (result f64)))
 (type $f64_f64_i32_=>_f64 (func (param f64 f64 i32) (result f64)))
 (type $i32_i32_i32_i32_i32_=>_i32 (func (param i32 i32 i32 i32 i32) (result i32)))
 (import "env" "core_math_scalbn" (func $core_math_scalbn (param f64 i32) (result i32)))
 (import "env" "floor" (func $floor (param f64) (result f64)))
 (global $__stack_pointer (mut i32) (i32.const 66912))
 (global $global$1 i32 (i32.const 1024))
 (global $global$2 i32 (i32.const 1376))
 (global $global$3 i32 (i32.const 1024))
 (global $global$4 i32 (i32.const 66912))
 (global $global$5 i32 (i32.const 0))
 (global $global$6 i32 (i32.const 1))
 (memory $0 16 16)
 (data $.rodata (i32.const 1024) "\03\00\00\00\04\00\00\00\04\00\00\00\06\00\00\00\83\f9\a2\00DNn\00\fc)\15\00\d1W\'\00\dd4\f5\00b\db\c0\00<\99\95\00A\90C\00cQ\fe\00\bb\de\ab\00\b7a\c5\00:n$\00\d2MB\00I\06\e0\00\t\ea.\00\1c\92\d1\00\eb\1d\fe\00)\b1\1c\00\e8>\a7\00\f55\82\00D\bb.\00\9c\e9\84\00\b4&p\00A~_\00\d6\919\00S\839\00\9c\f49\00\8b_\84\00(\f9\bd\00\f8\1f;\00\de\ff\97\00\0f\98\05\00\11/\ef\00\nZ\8b\00m\1fm\00\cf~6\00\t\cb\'\00FO\b7\00\9ef?\00-\ea_\00\ba\'u\00\e5\eb\c7\00={\f1\00\f79\07\00\92R\8a\00\fbk\ea\00\1f\b1_\00\08]\8d\000\03V\00{\fcF\00\f0\abk\00 \bc\cf\006\f4\9a\00\e3\a9\1d\00^a\91\00\08\1b\e6\00\85\99e\00\a0\14_\00\8d@h\00\80\d8\ff\00\'sM\00\06\061\00\caV\15\00\c9\a8s\00{\e2`\00k\8c\c0\00\00\00\00\00\00\00\00\00\00\00\00@\fb!\f9?\00\00\00\00-Dt>\00\00\00\80\98F\f8<\00\00\00`Q\ccx;\00\00\00\80\83\1b\f09\00\00\00@ %z8\00\00\00\80\"\82\e36\00\00\00\00\1d\f3i5")
 (table $0 1 1 funcref)
 (export "memory" (memory $0))
 (export "__wasm_call_ctors" (func $__wasm_call_ctors))
 (export "adder" (func $adder))
 (export "scalbn" (func $scalbn))
 (export "core_math___cos" (func $core_math___cos))
 (export "core_math___sin" (func $core_math___sin))
 (export "core_math___rem_pio2_large" (func $core_math___rem_pio2_large))
 (export "core_math___rem_pio2" (func $core_math___rem_pio2))
 (export "core_math_cos" (func $core_math_cos))
 (export "core_math_sin" (func $core_math_sin))
 (export "__indirect_function_table" (table $0))
 (export "__dso_handle" (global $global$1))
 (export "__data_end" (global $global$2))
 (export "__global_base" (global $global$3))
 (export "__heap_base" (global $global$4))
 (export "__memory_base" (global $global$5))
 (export "__table_base" (global $global$6))
 (func $__wasm_call_ctors
 )
 (func $adder (param $0 i32) (param $1 i32) (result i32)
  (i32.add
   (local.get $1)
   (local.get $0)
  )
 )
 (func $scalbn (param $0 f64) (param $1 i32) (result f64)
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.lt_s
      (local.get $1)
      (i32.const 1024)
     )
    )
    (block $label$3
     (br_if $label$3
      (i32.ge_u
       (local.get $1)
       (i32.const 2047)
      )
     )
     (local.set $1
      (i32.add
       (local.get $1)
       (i32.const -1023)
      )
     )
     (local.set $0
      (f64.mul
       (local.get $0)
       (f64.const 8988465674311579538646525e283)
      )
     )
     (br $label$1)
    )
    (local.set $1
     (i32.add
      (select
       (local.get $1)
       (i32.const 3069)
       (i32.lt_u
        (local.get $1)
        (i32.const 3069)
       )
      )
      (i32.const -2046)
     )
    )
    (br $label$1)
   )
   (br_if $label$1
    (i32.gt_s
     (local.get $1)
     (i32.const -1023)
    )
   )
   (block $label$4
    (br_if $label$4
     (i32.le_u
      (local.get $1)
      (i32.const -1992)
     )
    )
    (local.set $1
     (i32.add
      (local.get $1)
      (i32.const 969)
     )
    )
    (local.set $0
     (f64.mul
      (local.get $0)
      (f64.const 2.004168360008973e-292)
     )
    )
    (br $label$1)
   )
   (local.set $1
    (i32.add
     (select
      (local.get $1)
      (i32.const -2960)
      (i32.gt_u
       (local.get $1)
       (i32.const -2960)
      )
     )
     (i32.const 1938)
    )
   )
   (local.set $0
    (f64.const 0)
   )
  )
  (f64.mul
   (local.get $0)
   (f64.reinterpret_i64
    (i64.shl
     (i64.extend_i32_u
      (i32.add
       (local.get $1)
       (i32.const 1023)
      )
     )
     (i64.const 52)
    )
   )
  )
 )
 (func $core_math___cos (param $0 f64) (param $1 f64) (result f64)
  (f64.add
   (f64.sub
    (f64.const 1)
    (f64.mul
     (local.get $1)
     (local.get $0)
    )
   )
   (f64.mul
    (f64.add
     (f64.add
      (f64.mul
       (f64.mul
        (local.tee $1
         (f64.mul
          (local.tee $0
           (f64.mul
            (local.get $0)
            (local.get $0)
           )
          )
          (local.get $0)
         )
        )
        (local.get $1)
       )
       (f64.add
        (f64.mul
         (f64.add
          (f64.mul
           (local.get $0)
           (f64.const -1.1359647557788195e-11)
          )
          (f64.const 2.087572321298175e-09)
         )
         (local.get $0)
        )
        (f64.const -2.7557314351390663e-07)
       )
      )
      (f64.const -0.5)
     )
     (f64.mul
      (f64.add
       (f64.mul
        (f64.add
         (f64.mul
          (local.get $0)
          (f64.const 2.480158728947673e-05)
         )
         (f64.const -0.001388888888887411)
        )
        (local.get $0)
       )
       (f64.const 0.0416666666666666)
      )
      (local.get $0)
     )
    )
    (local.get $0)
   )
  )
 )
 (func $core_math___sin (param $0 f64) (param $1 f64) (param $2 i32) (result f64)
  (local $3 f64)
  (local $4 f64)
  (local $5 f64)
  (local.set $4
   (f64.mul
    (local.tee $3
     (f64.mul
      (local.get $0)
      (local.get $0)
     )
    )
    (local.get $0)
   )
  )
  (local.set $5
   (f64.add
    (f64.mul
     (f64.add
      (f64.mul
       (f64.add
        (f64.mul
         (f64.add
          (f64.mul
           (local.get $3)
           (f64.const 1.58969099521155e-10)
          )
          (f64.const -2.5050760253406863e-08)
         )
         (local.get $3)
        )
        (f64.const 2.7557313707070068e-06)
       )
       (local.get $3)
      )
      (f64.const -1.984126982985795e-04)
     )
     (local.get $3)
    )
    (f64.const 0.00833333333332249)
   )
  )
  (block $label$1
   (br_if $label$1
    (local.get $2)
   )
   (return
    (f64.add
     (f64.mul
      (f64.add
       (f64.mul
        (local.get $5)
        (local.get $3)
       )
       (f64.const -0.16666666666666632)
      )
      (local.get $4)
     )
     (local.get $0)
    )
   )
  )
  (f64.add
   (f64.add
    (f64.add
     (f64.mul
      (local.get $4)
      (f64.const -0.16666666666666632)
     )
     (local.get $1)
    )
    (f64.mul
     (f64.add
      (f64.mul
       (local.get $5)
       (local.get $4)
      )
      (f64.mul
       (local.get $1)
       (f64.const -0.5)
      )
     )
     (local.get $3)
    )
   )
   (local.get $0)
  )
 )
 (func $core_math___rem_pio2_large (param $0 i32) (param $1 i32) (param $2 i32) (param $3 i32) (param $4 i32) (result i32)
  (local $5 i32)
  (local $6 i32)
  (local $7 i32)
  (local $8 i32)
  (local $9 i32)
  (local $10 i32)
  (local $11 i32)
  (local $12 i32)
  (local $13 i32)
  (local $14 i32)
  (local $15 i32)
  (local $16 i32)
  (local $17 i32)
  (local $18 i32)
  (local $19 i32)
  (local $20 i32)
  (local $21 i32)
  (local $22 i32)
  (local $23 i32)
  (local $24 i32)
  (local $25 i32)
  (local $26 i32)
  (local $27 i32)
  (local $28 i32)
  (local $29 i32)
  (local $30 i32)
  (local $31 i32)
  (local $32 i32)
  (local $33 f64)
  (local $34 f64)
  (local $35 f64)
  (local $36 f64)
  (local $37 f64)
  (global.set $__stack_pointer
   (local.tee $5
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 560)
    )
   )
  )
  (local.set $6
   (i32.const 0)
  )
  (local.set $9
   (i32.mul
    (local.tee $8
     (select
      (local.tee $7
       (i32.div_s
        (i32.add
         (local.get $2)
         (i32.const -3)
        )
        (i32.const 24)
       )
      )
      (i32.const 0)
      (i32.gt_s
       (local.get $7)
       (i32.const 0)
      )
     )
    )
    (i32.const -24)
   )
  )
  (block $label$1
   (br_if $label$1
    (i32.lt_s
     (local.tee $7
      (i32.add
       (local.tee $10
        (i32.load
         (i32.add
          (i32.shl
           (local.get $4)
           (i32.const 2)
          )
          (i32.const 1024)
         )
        )
       )
       (local.tee $11
        (i32.add
         (local.get $3)
         (i32.const -1)
        )
       )
      )
     )
     (i32.const 0)
    )
   )
   (local.set $12
    (i32.sub
     (local.get $8)
     (local.get $11)
    )
   )
   (local.set $14
    (i32.and
     (local.tee $13
      (i32.add
       (local.get $10)
       (local.get $3)
      )
     )
     (i32.const 1)
    )
   )
   (block $label$2
    (br_if $label$2
     (i32.eqz
      (local.get $7)
     )
    )
    (local.set $15
     (i32.and
      (local.get $13)
      (i32.const -2)
     )
    )
    (local.set $13
     (i32.add
      (i32.shl
       (i32.sub
        (local.get $8)
        (local.get $3)
       )
       (i32.const 2)
      )
      (i32.const 1048)
     )
    )
    (local.set $7
     (i32.add
      (local.get $5)
      (i32.const 320)
     )
    )
    (local.set $6
     (i32.const 0)
    )
    (loop $label$3
     (local.set $33
      (f64.const 0)
     )
     (local.set $34
      (f64.const 0)
     )
     (block $label$4
      (br_if $label$4
       (i32.lt_s
        (local.tee $16
         (i32.add
          (local.get $12)
          (local.get $6)
         )
        )
        (i32.const 0)
       )
      )
      (local.set $34
       (f64.convert_i32_s
        (i32.load
         (i32.add
          (local.get $13)
          (i32.const -4)
         )
        )
       )
      )
     )
     (f64.store
      (local.get $7)
      (local.get $34)
     )
     (block $label$5
      (br_if $label$5
       (i32.lt_s
        (local.get $16)
        (i32.const -1)
       )
      )
      (local.set $33
       (f64.convert_i32_s
        (i32.load
         (local.get $13)
        )
       )
      )
     )
     (f64.store
      (i32.add
       (local.get $7)
       (i32.const 8)
      )
      (local.get $33)
     )
     (local.set $7
      (i32.add
       (local.get $7)
       (i32.const 16)
      )
     )
     (local.set $13
      (i32.add
       (local.get $13)
       (i32.const 8)
      )
     )
     (br_if $label$3
      (i32.ne
       (local.get $15)
       (local.tee $6
        (i32.add
         (local.get $6)
         (i32.const 2)
        )
       )
      )
     )
    )
    (local.set $12
     (i32.add
      (local.get $12)
      (local.get $6)
     )
    )
   )
   (br_if $label$1
    (i32.eqz
     (local.get $14)
    )
   )
   (block $label$6
    (block $label$7
     (br_if $label$7
      (i32.ge_s
       (local.get $12)
       (i32.const 0)
      )
     )
     (local.set $34
      (f64.const 0)
     )
     (br $label$6)
    )
    (local.set $34
     (f64.convert_i32_s
      (i32.load
       (i32.add
        (i32.shl
         (local.get $12)
         (i32.const 2)
        )
        (i32.const 1040)
       )
      )
     )
    )
   )
   (f64.store
    (i32.add
     (i32.add
      (local.get $5)
      (i32.const 320)
     )
     (i32.shl
      (local.get $6)
      (i32.const 3)
     )
    )
    (local.get $34)
   )
  )
  (local.set $17
   (i32.add
    (local.get $9)
    (local.get $2)
   )
  )
  (local.set $13
   (i32.const 0)
  )
  (local.set $2
   (select
    (local.get $10)
    (i32.const 0)
    (i32.gt_s
     (local.get $10)
     (i32.const 0)
    )
   )
  )
  (block $label$8
   (block $label$9
    (br_if $label$9
     (i32.gt_s
      (local.get $3)
      (i32.const 0)
     )
    )
    (local.set $6
     (i32.and
      (local.tee $7
       (i32.add
        (local.get $2)
        (i32.const 1)
       )
      )
      (i32.const 7)
     )
    )
    (block $label$10
     (br_if $label$10
      (i32.lt_u
       (local.get $2)
       (i32.const 7)
      )
     )
     (local.set $16
      (i32.and
       (local.get $7)
       (i32.const -8)
      )
     )
     (local.set $7
      (i32.add
       (local.get $5)
       (i32.const 32)
      )
     )
     (local.set $13
      (i32.const 0)
     )
     (loop $label$11
      (i64.store
       (local.get $7)
       (i64.const 0)
      )
      (i64.store
       (i32.add
        (local.get $7)
        (i32.const 24)
       )
       (i64.const 0)
      )
      (i64.store
       (i32.add
        (local.get $7)
        (i32.const 16)
       )
       (i64.const 0)
      )
      (i64.store
       (i32.add
        (local.get $7)
        (i32.const 8)
       )
       (i64.const 0)
      )
      (i64.store
       (i32.add
        (local.get $7)
        (i32.const -8)
       )
       (i64.const 0)
      )
      (i64.store
       (i32.add
        (local.get $7)
        (i32.const -16)
       )
       (i64.const 0)
      )
      (i64.store
       (i32.add
        (local.get $7)
        (i32.const -24)
       )
       (i64.const 0)
      )
      (i64.store
       (i32.add
        (local.get $7)
        (i32.const -32)
       )
       (i64.const 0)
      )
      (local.set $7
       (i32.add
        (local.get $7)
        (i32.const 64)
       )
      )
      (br_if $label$11
       (i32.ne
        (local.get $16)
        (local.tee $13
         (i32.add
          (local.get $13)
          (i32.const 8)
         )
        )
       )
      )
     )
    )
    (br_if $label$8
     (i32.eqz
      (local.get $6)
     )
    )
    (local.set $7
     (i32.add
      (local.get $5)
      (i32.shl
       (local.get $13)
       (i32.const 3)
      )
     )
    )
    (loop $label$12
     (i64.store
      (local.get $7)
      (i64.const 0)
     )
     (local.set $7
      (i32.add
       (local.get $7)
       (i32.const 8)
      )
     )
     (br_if $label$12
      (local.tee $6
       (i32.add
        (local.get $6)
        (i32.const -1)
       )
      )
     )
     (br $label$8)
    )
   )
   (local.set $16
    (i32.and
     (local.get $3)
     (i32.const -2)
    )
   )
   (local.set $9
    (i32.and
     (local.get $3)
     (i32.const 1)
    )
   )
   (local.set $15
    (i32.add
     (i32.add
      (i32.shl
       (local.get $3)
       (i32.const 3)
      )
      (i32.add
       (local.get $5)
       (i32.const 320)
      )
     )
     (i32.const -16)
    )
   )
   (local.set $12
    (i32.const 0)
   )
   (loop $label$13
    (block $label$14
     (block $label$15
      (br_if $label$15
       (local.get $11)
      )
      (local.set $34
       (f64.const 0)
      )
      (local.set $13
       (i32.const 0)
      )
      (br $label$14)
     )
     (local.set $13
      (i32.const 0)
     )
     (local.set $34
      (f64.const 0)
     )
     (local.set $7
      (local.get $15)
     )
     (local.set $6
      (local.get $0)
     )
     (loop $label$16
      (local.set $34
       (f64.add
        (f64.mul
         (f64.load
          (local.get $7)
         )
         (f64.load
          (i32.add
           (local.get $6)
           (i32.const 8)
          )
         )
        )
        (f64.add
         (f64.mul
          (f64.load
           (i32.add
            (local.get $7)
            (i32.const 8)
           )
          )
          (f64.load
           (local.get $6)
          )
         )
         (local.get $34)
        )
       )
      )
      (local.set $7
       (i32.add
        (local.get $7)
        (i32.const -16)
       )
      )
      (local.set $6
       (i32.add
        (local.get $6)
        (i32.const 16)
       )
      )
      (br_if $label$16
       (i32.ne
        (local.get $16)
        (local.tee $13
         (i32.add
          (local.get $13)
          (i32.const 2)
         )
        )
       )
      )
     )
    )
    (block $label$17
     (br_if $label$17
      (i32.eqz
       (local.get $9)
      )
     )
     (local.set $34
      (f64.add
       (f64.mul
        (f64.load
         (i32.add
          (i32.add
           (local.get $5)
           (i32.const 320)
          )
          (i32.shl
           (i32.sub
            (i32.add
             (local.get $12)
             (local.get $11)
            )
            (local.get $13)
           )
           (i32.const 3)
          )
         )
        )
        (f64.load
         (i32.add
          (local.get $0)
          (i32.shl
           (local.get $13)
           (i32.const 3)
          )
         )
        )
       )
       (local.get $34)
      )
     )
    )
    (f64.store
     (i32.add
      (local.get $5)
      (i32.shl
       (local.get $12)
       (i32.const 3)
      )
     )
     (local.get $34)
    )
    (local.set $15
     (i32.add
      (local.get $15)
      (i32.const 8)
     )
    )
    (local.set $7
     (i32.eq
      (local.get $12)
      (local.get $2)
     )
    )
    (local.set $12
     (i32.add
      (local.get $12)
      (i32.const 1)
     )
    )
    (br_if $label$13
     (i32.eqz
      (local.get $7)
     )
    )
   )
  )
  (local.set $18
   (i32.add
    (local.get $17)
    (i32.const -24)
   )
  )
  (local.set $16
   (i32.and
    (local.get $3)
    (i32.const -2)
   )
  )
  (local.set $14
   (i32.and
    (local.get $3)
    (i32.const 1)
   )
  )
  (local.set $19
   (i32.xor
    (local.get $10)
    (i32.const -1)
   )
  )
  (local.set $20
   (i32.sub
    (i32.const 47)
    (local.get $17)
   )
  )
  (local.set $21
   (i32.sub
    (i32.const 48)
    (local.get $17)
   )
  )
  (local.set $22
   (i32.add
    (i32.add
     (i32.shl
      (local.get $10)
      (i32.const 2)
     )
     (i32.add
      (local.get $5)
      (i32.const 480)
     )
    )
    (i32.const -4)
   )
  )
  (local.set $23
   (i32.add
    (i32.add
     (local.get $5)
     (i32.const 320)
    )
    (i32.const -8)
   )
  )
  (local.set $24
   (i32.add
    (i32.add
     (local.get $5)
     (i32.const 480)
    )
    (i32.const -4)
   )
  )
  (local.set $25
   (i32.add
    (i32.add
     (local.get $5)
     (i32.const 480)
    )
    (i32.const -16)
   )
  )
  (local.set $26
   (i32.add
    (local.get $5)
    (i32.const -16)
   )
  )
  (local.set $27
   (i32.add
    (local.get $17)
    (i32.const -25)
   )
  )
  (local.set $12
   (local.get $10)
  )
  (block $label$18
   (loop $label$19
    (local.set $34
     (f64.load
      (i32.add
       (local.get $5)
       (local.tee $7
        (i32.shl
         (local.get $12)
         (i32.const 3)
        )
       )
      )
     )
    )
    (block $label$20
     (br_if $label$20
      (local.tee $9
       (i32.lt_s
        (local.get $12)
        (i32.const 1)
       )
      )
     )
     (local.set $28
      (i32.and
       (local.get $12)
       (i32.const 1)
      )
     )
     (local.set $13
      (i32.const 0)
     )
     (block $label$21
      (block $label$22
       (br_if $label$22
        (i32.ne
         (local.get $12)
         (i32.const 1)
        )
       )
       (local.set $7
        (local.get $12)
       )
       (br $label$21)
      )
      (local.set $2
       (i32.and
        (local.get $12)
        (i32.const -2)
       )
      )
      (local.set $7
       (i32.add
        (local.get $26)
        (local.get $7)
       )
      )
      (local.set $13
       (i32.const 0)
      )
      (local.set $6
       (i32.add
        (local.get $5)
        (i32.const 480)
       )
      )
      (loop $label$23
       (block $label$24
        (block $label$25
         (br_if $label$25
          (i32.eqz
           (f64.lt
            (f64.abs
             (local.tee $34
              (f64.sub
               (local.get $34)
               (f64.mul
                (local.tee $33
                 (f64.trunc
                  (f64.mul
                   (local.get $34)
                   (f64.const 5.9604644775390625e-08)
                  )
                 )
                )
                (f64.const 16777216)
               )
              )
             )
            )
            (f64.const 2147483648)
           )
          )
         )
         (local.set $15
          (i32.trunc_f64_s
           (local.get $34)
          )
         )
         (br $label$24)
        )
        (local.set $15
         (i32.const -2147483648)
        )
       )
       (i32.store
        (local.get $6)
        (local.get $15)
       )
       (block $label$26
        (block $label$27
         (br_if $label$27
          (i32.eqz
           (f64.lt
            (f64.abs
             (local.tee $33
              (f64.sub
               (local.tee $34
                (f64.add
                 (f64.load
                  (i32.add
                   (local.get $7)
                   (i32.const 8)
                  )
                 )
                 (local.get $33)
                )
               )
               (f64.mul
                (local.tee $34
                 (f64.trunc
                  (f64.mul
                   (local.get $34)
                   (f64.const 5.9604644775390625e-08)
                  )
                 )
                )
                (f64.const 16777216)
               )
              )
             )
            )
            (f64.const 2147483648)
           )
          )
         )
         (local.set $15
          (i32.trunc_f64_s
           (local.get $33)
          )
         )
         (br $label$26)
        )
        (local.set $15
         (i32.const -2147483648)
        )
       )
       (i32.store
        (i32.add
         (local.get $6)
         (i32.const 4)
        )
        (local.get $15)
       )
       (local.set $34
        (f64.add
         (f64.load
          (local.get $7)
         )
         (local.get $34)
        )
       )
       (local.set $6
        (i32.add
         (local.get $6)
         (i32.const 8)
        )
       )
       (local.set $7
        (i32.add
         (local.get $7)
         (i32.const -16)
        )
       )
       (br_if $label$23
        (i32.ne
         (local.get $2)
         (local.tee $13
          (i32.add
           (local.get $13)
           (i32.const 2)
          )
         )
        )
       )
      )
      (local.set $7
       (i32.sub
        (local.get $12)
        (local.get $13)
       )
      )
     )
     (br_if $label$20
      (i32.eqz
       (local.get $28)
      )
     )
     (local.set $6
      (i32.add
       (i32.add
        (local.get $5)
        (i32.const 480)
       )
       (i32.shl
        (local.get $13)
        (i32.const 2)
       )
      )
     )
     (block $label$28
      (block $label$29
       (br_if $label$29
        (i32.eqz
         (f64.lt
          (f64.abs
           (local.tee $34
            (f64.add
             (local.get $34)
             (f64.mul
              (local.tee $33
               (f64.trunc
                (f64.mul
                 (local.get $34)
                 (f64.const 5.9604644775390625e-08)
                )
               )
              )
              (f64.const -16777216)
             )
            )
           )
          )
          (f64.const 2147483648)
         )
        )
       )
       (local.set $13
        (i32.trunc_f64_s
         (local.get $34)
        )
       )
       (br $label$28)
      )
      (local.set $13
       (i32.const -2147483648)
      )
     )
     (i32.store
      (local.get $6)
      (local.get $13)
     )
     (local.set $34
      (f64.add
       (f64.load
        (i32.add
         (i32.add
          (i32.shl
           (local.get $7)
           (i32.const 3)
          )
          (local.get $5)
         )
         (i32.const -8)
        )
       )
       (local.get $33)
      )
     )
    )
    (local.set $34
     (f64.convert_i32_s
      (call $core_math_scalbn
       (local.get $34)
       (local.get $18)
      )
     )
    )
    (local.set $33
     (f64.trunc
      (local.tee $34
       (f64.add
        (local.get $34)
        (f64.mul
         (call $floor
          (f64.mul
           (local.get $34)
           (f64.const 0.125)
          )
         )
         (f64.const -8)
        )
       )
      )
     )
    )
    (block $label$30
     (block $label$31
      (br_if $label$31
       (i32.eqz
        (f64.lt
         (f64.abs
          (local.get $34)
         )
         (f64.const 2147483648)
        )
       )
      )
      (local.set $29
       (i32.trunc_f64_s
        (local.get $34)
       )
      )
      (br $label$30)
     )
     (local.set $29
      (i32.const -2147483648)
     )
    )
    (local.set $34
     (f64.sub
      (local.get $34)
      (local.get $33)
     )
    )
    (block $label$32
     (block $label$33
      (block $label$34
       (block $label$35
        (block $label$36
         (br_if $label$36
          (local.tee $30
           (i32.lt_s
            (local.get $18)
            (i32.const 1)
           )
          )
         )
         (i32.store
          (local.tee $7
           (i32.add
            (i32.add
             (i32.shl
              (local.get $12)
              (i32.const 2)
             )
             (i32.add
              (local.get $5)
              (i32.const 480)
             )
            )
            (i32.const -4)
           )
          )
          (local.tee $6
           (i32.sub
            (local.tee $7
             (i32.load
              (local.get $7)
             )
            )
            (i32.shl
             (local.tee $7
              (i32.shr_s
               (local.get $7)
               (local.get $21)
              )
             )
             (local.get $21)
            )
           )
          )
         )
         (local.set $31
          (i32.shr_s
           (local.get $6)
           (local.get $20)
          )
         )
         (local.set $29
          (i32.add
           (local.get $7)
           (local.get $29)
          )
         )
         (br $label$35)
        )
        (br_if $label$34
         (local.get $18)
        )
        (local.set $31
         (i32.shr_s
          (i32.load
           (i32.add
            (i32.add
             (i32.shl
              (local.get $12)
              (i32.const 2)
             )
             (i32.add
              (local.get $5)
              (i32.const 480)
             )
            )
            (i32.const -4)
           )
          )
          (i32.const 23)
         )
        )
       )
       (br_if $label$32
        (i32.lt_s
         (local.get $31)
         (i32.const 1)
        )
       )
       (br $label$33)
      )
      (local.set $31
       (i32.const 2)
      )
      (br_if $label$33
       (i32.eqz
        (f64.lt
         (local.get $34)
         (f64.const 0.5)
        )
       )
      )
      (local.set $31
       (i32.const 0)
      )
      (br $label$32)
     )
     (block $label$37
      (block $label$38
       (br_if $label$38
        (i32.eqz
         (local.get $9)
        )
       )
       (local.set $6
        (i32.const 0)
       )
       (br $label$37)
      )
      (local.set $32
       (i32.and
        (local.get $12)
        (i32.const 1)
       )
      )
      (local.set $2
       (i32.const 0)
      )
      (local.set $6
       (i32.const 0)
      )
      (block $label$39
       (br_if $label$39
        (i32.eq
         (local.get $12)
         (i32.const 1)
        )
       )
       (local.set $28
        (i32.and
         (local.get $12)
         (i32.const -2)
        )
       )
       (local.set $2
        (i32.const 0)
       )
       (local.set $7
        (i32.add
         (local.get $5)
         (i32.const 480)
        )
       )
       (local.set $6
        (i32.const 0)
       )
       (loop $label$40
        (local.set $13
         (i32.load
          (local.get $7)
         )
        )
        (local.set $15
         (i32.const 16777215)
        )
        (block $label$41
         (block $label$42
          (br_if $label$42
           (local.get $6)
          )
          (local.set $15
           (i32.const 16777216)
          )
          (br_if $label$42
           (local.get $13)
          )
          (local.set $15
           (i32.const 1)
          )
          (br $label$41)
         )
         (i32.store
          (local.get $7)
          (i32.sub
           (local.get $15)
           (local.get $13)
          )
         )
         (local.set $15
          (i32.const 0)
         )
        )
        (local.set $13
         (i32.load
          (local.tee $9
           (i32.add
            (local.get $7)
            (i32.const 4)
           )
          )
         )
        )
        (local.set $6
         (i32.const 16777215)
        )
        (block $label$43
         (block $label$44
          (br_if $label$44
           (i32.eqz
            (local.get $15)
           )
          )
          (local.set $6
           (i32.const 16777216)
          )
          (br_if $label$44
           (local.get $13)
          )
          (local.set $6
           (i32.const 0)
          )
          (br $label$43)
         )
         (i32.store
          (local.get $9)
          (i32.sub
           (local.get $6)
           (local.get $13)
          )
         )
         (local.set $6
          (i32.const 1)
         )
        )
        (local.set $7
         (i32.add
          (local.get $7)
          (i32.const 8)
         )
        )
        (br_if $label$40
         (i32.ne
          (local.get $28)
          (local.tee $2
           (i32.add
            (local.get $2)
            (i32.const 2)
           )
          )
         )
        )
       )
      )
      (br_if $label$37
       (i32.eqz
        (local.get $32)
       )
      )
      (local.set $7
       (i32.load
        (local.tee $15
         (i32.add
          (i32.add
           (local.get $5)
           (i32.const 480)
          )
          (i32.shl
           (local.get $2)
           (i32.const 2)
          )
         )
        )
       )
      )
      (local.set $13
       (i32.const 16777215)
      )
      (block $label$45
       (br_if $label$45
        (local.get $6)
       )
       (local.set $13
        (i32.const 16777216)
       )
       (br_if $label$45
        (local.get $7)
       )
       (local.set $6
        (i32.const 0)
       )
       (br $label$37)
      )
      (i32.store
       (local.get $15)
       (i32.sub
        (local.get $13)
        (local.get $7)
       )
      )
      (local.set $6
       (i32.const 1)
      )
     )
     (block $label$46
      (br_if $label$46
       (local.get $30)
      )
      (local.set $7
       (i32.const 8388607)
      )
      (block $label$47
       (block $label$48
        (br_table $label$47 $label$48 $label$46
         (local.get $27)
        )
       )
       (local.set $7
        (i32.const 4194303)
       )
      )
      (i32.store
       (local.tee $13
        (i32.add
         (i32.add
          (i32.shl
           (local.get $12)
           (i32.const 2)
          )
          (i32.add
           (local.get $5)
           (i32.const 480)
          )
         )
         (i32.const -4)
        )
       )
       (i32.and
        (i32.load
         (local.get $13)
        )
        (local.get $7)
       )
      )
     )
     (local.set $29
      (i32.add
       (local.get $29)
       (i32.const 1)
      )
     )
     (br_if $label$32
      (i32.ne
       (local.get $31)
       (i32.const 2)
      )
     )
     (local.set $34
      (f64.sub
       (f64.const 1)
       (local.get $34)
      )
     )
     (local.set $31
      (i32.const 2)
     )
     (br_if $label$32
      (i32.eqz
       (local.get $6)
      )
     )
     (local.set $34
      (f64.sub
       (local.get $34)
       (f64.convert_i32_s
        (call $core_math_scalbn
         (f64.const 1)
         (local.get $18)
        )
       )
      )
     )
    )
    (block $label$49
     (br_if $label$49
      (f64.ne
       (local.get $34)
       (f64.const 0)
      )
     )
     (block $label$50
      (br_if $label$50
       (i32.le_s
        (local.get $12)
        (local.get $10)
       )
      )
      (local.set $13
       (i32.and
        (local.tee $7
         (i32.sub
          (local.get $12)
          (local.get $10)
         )
        )
        (i32.const 3)
       )
      )
      (local.set $6
       (i32.const 0)
      )
      (local.set $15
       (local.get $12)
      )
      (block $label$51
       (br_if $label$51
        (i32.lt_u
         (i32.add
          (local.get $12)
          (local.get $19)
         )
         (i32.const 3)
        )
       )
       (local.set $2
        (i32.and
         (local.get $7)
         (i32.const -4)
        )
       )
       (local.set $7
        (i32.add
         (local.get $25)
         (i32.shl
          (local.get $12)
          (i32.const 2)
         )
        )
       )
       (local.set $6
        (i32.const 0)
       )
       (local.set $15
        (local.get $12)
       )
       (loop $label$52
        (local.set $6
         (i32.or
          (i32.load
           (local.get $7)
          )
          (i32.or
           (i32.load
            (i32.add
             (local.get $7)
             (i32.const 4)
            )
           )
           (i32.or
            (i32.load
             (i32.add
              (local.get $7)
              (i32.const 8)
             )
            )
            (i32.or
             (i32.load
              (i32.add
               (local.get $7)
               (i32.const 12)
              )
             )
             (local.get $6)
            )
           )
          )
         )
        )
        (local.set $7
         (i32.add
          (local.get $7)
          (i32.const -16)
         )
        )
        (local.set $15
         (i32.add
          (local.get $15)
          (i32.const -4)
         )
        )
        (br_if $label$52
         (local.tee $2
          (i32.add
           (local.get $2)
           (i32.const -4)
          )
         )
        )
       )
      )
      (block $label$53
       (br_if $label$53
        (i32.eqz
         (local.get $13)
        )
       )
       (local.set $7
        (i32.add
         (local.get $24)
         (i32.shl
          (local.get $15)
          (i32.const 2)
         )
        )
       )
       (loop $label$54
        (local.set $6
         (i32.or
          (i32.load
           (local.get $7)
          )
          (local.get $6)
         )
        )
        (local.set $7
         (i32.add
          (local.get $7)
          (i32.const -4)
         )
        )
        (br_if $label$54
         (local.tee $13
          (i32.add
           (local.get $13)
           (i32.const -1)
          )
         )
        )
       )
      )
      (br_if $label$50
       (i32.eqz
        (local.get $6)
       )
      )
      (local.set $7
       (i32.add
        (i32.add
         (i32.add
          (local.get $5)
          (i32.const 480)
         )
         (i32.shl
          (local.get $12)
          (i32.const 2)
         )
        )
        (i32.const -4)
       )
      )
      (local.set $17
       (local.get $18)
      )
      (loop $label$55
       (local.set $12
        (i32.add
         (local.get $12)
         (i32.const -1)
        )
       )
       (local.set $17
        (i32.add
         (local.get $17)
         (i32.const -24)
        )
       )
       (local.set $6
        (i32.load
         (local.get $7)
        )
       )
       (local.set $7
        (i32.add
         (local.get $7)
         (i32.const -4)
        )
       )
       (br_if $label$55
        (i32.eqz
         (local.get $6)
        )
       )
       (br $label$18)
      )
     )
     (local.set $7
      (local.get $22)
     )
     (local.set $15
      (local.get $12)
     )
     (loop $label$56
      (local.set $15
       (i32.add
        (local.get $15)
        (i32.const 1)
       )
      )
      (local.set $6
       (i32.load
        (local.get $7)
       )
      )
      (local.set $7
       (i32.add
        (local.get $7)
        (i32.const -4)
       )
      )
      (br_if $label$56
       (i32.eqz
        (local.get $6)
       )
      )
     )
     (local.set $2
      (i32.add
       (local.get $23)
       (i32.shl
        (i32.add
         (local.get $3)
         (local.get $12)
        )
        (i32.const 3)
       )
      )
     )
     (loop $label$57
      (f64.store
       (i32.add
        (i32.add
         (local.get $5)
         (i32.const 320)
        )
        (i32.shl
         (local.tee $9
          (i32.add
           (local.get $12)
           (local.get $3)
          )
         )
         (i32.const 3)
        )
       )
       (f64.convert_i32_s
        (i32.load
         (i32.add
          (i32.shl
           (i32.add
            (local.tee $12
             (i32.add
              (local.get $12)
              (i32.const 1)
             )
            )
            (local.get $8)
           )
           (i32.const 2)
          )
          (i32.const 1040)
         )
        )
       )
      )
      (block $label$58
       (block $label$59
        (br_if $label$59
         (i32.ge_s
          (local.get $3)
          (i32.const 1)
         )
        )
        (local.set $34
         (f64.const 0)
        )
        (br $label$58)
       )
       (local.set $13
        (i32.const 0)
       )
       (local.set $34
        (f64.const 0)
       )
       (block $label$60
        (br_if $label$60
         (i32.eqz
          (local.get $11)
         )
        )
        (local.set $7
         (local.get $2)
        )
        (local.set $6
         (local.get $0)
        )
        (loop $label$61
         (local.set $34
          (f64.add
           (f64.mul
            (f64.load
             (local.get $7)
            )
            (f64.load
             (i32.add
              (local.get $6)
              (i32.const 8)
             )
            )
           )
           (f64.add
            (f64.mul
             (f64.load
              (i32.add
               (local.get $7)
               (i32.const 8)
              )
             )
             (f64.load
              (local.get $6)
             )
            )
            (local.get $34)
           )
          )
         )
         (local.set $7
          (i32.add
           (local.get $7)
           (i32.const -16)
          )
         )
         (local.set $6
          (i32.add
           (local.get $6)
           (i32.const 16)
          )
         )
         (br_if $label$61
          (i32.ne
           (local.get $16)
           (local.tee $13
            (i32.add
             (local.get $13)
             (i32.const 2)
            )
           )
          )
         )
        )
       )
       (br_if $label$58
        (i32.eqz
         (local.get $14)
        )
       )
       (local.set $34
        (f64.add
         (f64.mul
          (f64.load
           (i32.add
            (i32.add
             (local.get $5)
             (i32.const 320)
            )
            (i32.shl
             (i32.sub
              (local.get $9)
              (local.get $13)
             )
             (i32.const 3)
            )
           )
          )
          (f64.load
           (i32.add
            (local.get $0)
            (i32.shl
             (local.get $13)
             (i32.const 3)
            )
           )
          )
         )
         (local.get $34)
        )
       )
      )
      (f64.store
       (i32.add
        (local.get $5)
        (i32.shl
         (local.get $12)
         (i32.const 3)
        )
       )
       (local.get $34)
      )
      (local.set $2
       (i32.add
        (local.get $2)
        (i32.const 8)
       )
      )
      (br_if $label$57
       (i32.lt_s
        (local.get $12)
        (local.get $15)
       )
      )
     )
     (local.set $12
      (local.get $15)
     )
     (br $label$19)
    )
   )
   (block $label$62
    (block $label$63
     (br_if $label$63
      (i32.ge_s
       (local.tee $7
        (call $core_math_scalbn
         (local.get $34)
         (i32.sub
          (i32.const 24)
          (local.get $17)
         )
        )
       )
       (i32.const 16777216)
      )
     )
     (local.set $17
      (local.get $18)
     )
     (br $label$62)
    )
    (local.set $6
     (i32.add
      (i32.add
       (local.get $5)
       (i32.const 480)
      )
      (i32.shl
       (local.get $12)
       (i32.const 2)
      )
     )
    )
    (block $label$64
     (block $label$65
      (br_if $label$65
       (i32.eqz
        (f64.lt
         (f64.abs
          (local.tee $33
           (f64.add
            (local.tee $34
             (f64.convert_i32_s
              (local.get $7)
             )
            )
            (f64.mul
             (f64.trunc
              (local.tee $34
               (f64.mul
                (local.get $34)
                (f64.const 5.9604644775390625e-08)
               )
              )
             )
             (f64.const -16777216)
            )
           )
          )
         )
         (f64.const 2147483648)
        )
       )
      )
      (local.set $7
       (i32.trunc_f64_s
        (local.get $33)
       )
      )
      (br $label$64)
     )
     (local.set $7
      (i32.const -2147483648)
     )
    )
    (i32.store
     (local.get $6)
     (local.get $7)
    )
    (block $label$66
     (block $label$67
      (br_if $label$67
       (i32.eqz
        (f64.lt
         (f64.abs
          (local.get $34)
         )
         (f64.const 2147483648)
        )
       )
      )
      (local.set $7
       (i32.trunc_f64_s
        (local.get $34)
       )
      )
      (br $label$66)
     )
     (local.set $7
      (i32.const -2147483648)
     )
    )
    (local.set $12
     (i32.add
      (local.get $12)
      (i32.const 1)
     )
    )
   )
   (i32.store
    (i32.add
     (i32.add
      (local.get $5)
      (i32.const 480)
     )
     (i32.shl
      (local.get $12)
      (i32.const 2)
     )
    )
    (local.get $7)
   )
  )
  (local.set $7
   (call $core_math_scalbn
    (f64.const 1)
    (local.get $17)
   )
  )
  (block $label$68
   (br_if $label$68
    (i32.lt_s
     (local.get $12)
     (i32.const 0)
    )
   )
   (local.set $34
    (f64.convert_i32_s
     (local.get $7)
    )
   )
   (block $label$69
    (block $label$70
     (br_if $label$70
      (i32.eqz
       (i32.and
        (local.get $12)
        (i32.const 1)
       )
      )
     )
     (local.set $7
      (local.get $12)
     )
     (br $label$69)
    )
    (f64.store
     (i32.add
      (local.get $5)
      (i32.shl
       (local.get $12)
       (i32.const 3)
      )
     )
     (f64.mul
      (local.get $34)
      (f64.convert_i32_s
       (i32.load
        (i32.add
         (i32.add
          (local.get $5)
          (i32.const 480)
         )
         (i32.shl
          (local.get $12)
          (i32.const 2)
         )
        )
       )
      )
     )
    )
    (local.set $7
     (i32.add
      (local.get $12)
      (i32.const -1)
     )
    )
    (local.set $34
     (f64.mul
      (local.get $34)
      (f64.const 5.9604644775390625e-08)
     )
    )
   )
   (block $label$71
    (br_if $label$71
     (i32.eqz
      (local.get $12)
     )
    )
    (local.set $13
     (i32.add
      (local.get $7)
      (i32.const 1)
     )
    )
    (local.set $7
     (i32.add
      (i32.add
       (local.get $5)
       (i32.const 480)
      )
      (i32.shl
       (local.tee $6
        (i32.add
         (local.get $7)
         (i32.const -1)
        )
       )
       (i32.const 2)
      )
     )
    )
    (local.set $6
     (i32.add
      (local.get $5)
      (i32.shl
       (local.get $6)
       (i32.const 3)
      )
     )
    )
    (loop $label$72
     (f64.store
      (local.get $6)
      (f64.mul
       (f64.mul
        (local.get $34)
        (f64.const 5.9604644775390625e-08)
       )
       (f64.convert_i32_s
        (i32.load
         (local.get $7)
        )
       )
      )
     )
     (f64.store
      (i32.add
       (local.get $6)
       (i32.const 8)
      )
      (f64.mul
       (local.get $34)
       (f64.convert_i32_s
        (i32.load
         (i32.add
          (local.get $7)
          (i32.const 4)
         )
        )
       )
      )
     )
     (local.set $7
      (i32.add
       (local.get $7)
       (i32.const -8)
      )
     )
     (local.set $6
      (i32.add
       (local.get $6)
       (i32.const -16)
      )
     )
     (local.set $34
      (f64.mul
       (local.get $34)
       (f64.const 3.552713678800501e-15)
      )
     )
     (br_if $label$72
      (local.tee $13
       (i32.add
        (local.get $13)
        (i32.const -2)
       )
      )
     )
    )
   )
   (br_if $label$68
    (i32.lt_s
     (local.get $12)
     (i32.const 0)
    )
   )
   (local.set $16
    (i32.add
     (local.get $5)
     (i32.shl
      (local.get $12)
      (i32.const 3)
     )
    )
   )
   (local.set $7
    (local.get $12)
   )
   (loop $label$73
    (local.set $15
     (i32.sub
      (local.get $12)
      (local.tee $2
       (local.get $7)
      )
     )
    )
    (local.set $34
     (f64.const 0)
    )
    (local.set $7
     (i32.const 0)
    )
    (local.set $6
     (i32.const 0)
    )
    (block $label$74
     (loop $label$75
      (local.set $34
       (f64.add
        (f64.mul
         (f64.load
          (i32.add
           (local.get $16)
           (local.get $7)
          )
         )
         (f64.load
          (i32.add
           (local.get $7)
           (i32.const 1312)
          )
         )
        )
        (local.get $34)
       )
      )
      (br_if $label$74
       (i32.ge_s
        (local.get $6)
        (local.get $10)
       )
      )
      (local.set $7
       (i32.add
        (local.get $7)
        (i32.const 8)
       )
      )
      (local.set $13
       (i32.lt_u
        (local.get $6)
        (local.get $15)
       )
      )
      (local.set $6
       (i32.add
        (local.get $6)
        (i32.const 1)
       )
      )
      (br_if $label$75
       (local.get $13)
      )
     )
    )
    (f64.store
     (i32.add
      (i32.add
       (local.get $5)
       (i32.const 160)
      )
      (i32.shl
       (local.get $15)
       (i32.const 3)
      )
     )
     (local.get $34)
    )
    (local.set $16
     (i32.add
      (local.get $16)
      (i32.const -8)
     )
    )
    (local.set $7
     (i32.add
      (local.get $2)
      (i32.const -1)
     )
    )
    (br_if $label$73
     (i32.gt_s
      (local.get $2)
      (i32.const 0)
     )
    )
   )
  )
  (block $label$76
   (block $label$77
    (block $label$78
     (block $label$79
      (block $label$80
       (block $label$81
        (block $label$82
         (br_table $label$81 $label$80 $label$80 $label$82 $label$76
          (local.get $4)
         )
        )
        (local.set $35
         (f64.const 0)
        )
        (br_if $label$77
         (i32.lt_s
          (local.get $12)
          (i32.const 1)
         )
        )
        (local.set $16
         (i32.add
          (local.get $12)
          (i32.const -1)
         )
        )
        (local.set $34
         (f64.load
          (i32.add
           (i32.add
            (local.get $5)
            (i32.const 160)
           )
           (i32.shl
            (local.get $12)
            (i32.const 3)
           )
          )
         )
        )
        (block $label$83
         (block $label$84
          (br_if $label$84
           (local.tee $13
            (i32.and
             (local.get $12)
             (i32.const 3)
            )
           )
          )
          (local.set $6
           (local.get $12)
          )
          (br $label$83)
         )
         (local.set $7
          (i32.add
           (i32.add
            (local.get $5)
            (i32.const 160)
           )
           (i32.shl
            (local.get $16)
            (i32.const 3)
           )
          )
         )
         (local.set $6
          (local.get $12)
         )
         (loop $label$85
          (i64.store
           (i32.add
            (local.get $7)
            (i32.const 8)
           )
           (i64.const 0)
          )
          (f64.store
           (local.get $7)
           (local.tee $34
            (f64.add
             (local.get $34)
             (f64.load
              (local.get $7)
             )
            )
           )
          )
          (local.set $7
           (i32.add
            (local.get $7)
            (i32.const -8)
           )
          )
          (local.set $6
           (i32.add
            (local.get $6)
            (i32.const -1)
           )
          )
          (br_if $label$85
           (local.tee $13
            (i32.add
             (local.get $13)
             (i32.const -1)
            )
           )
          )
         )
        )
        (block $label$86
         (br_if $label$86
          (i32.lt_u
           (local.get $16)
           (i32.const 3)
          )
         )
         (local.set $13
          (i32.add
           (local.get $6)
           (i32.const 1)
          )
         )
         (local.set $7
          (i32.add
           (i32.add
            (i32.shl
             (local.get $6)
             (i32.const 3)
            )
            (i32.add
             (local.get $5)
             (i32.const 160)
            )
           )
           (i32.const -32)
          )
         )
         (loop $label$87
          (i64.store
           (i32.add
            (local.get $7)
            (i32.const 32)
           )
           (i64.const 0)
          )
          (local.set $33
           (f64.load
            (local.tee $6
             (i32.add
              (local.get $7)
              (i32.const 24)
             )
            )
           )
          )
          (i64.store
           (local.get $6)
           (i64.const 0)
          )
          (local.set $36
           (f64.load
            (local.tee $6
             (i32.add
              (local.get $7)
              (i32.const 16)
             )
            )
           )
          )
          (i64.store
           (local.get $6)
           (i64.const 0)
          )
          (local.set $37
           (f64.load
            (local.tee $6
             (i32.add
              (local.get $7)
              (i32.const 8)
             )
            )
           )
          )
          (i64.store
           (local.get $6)
           (i64.const 0)
          )
          (f64.store
           (local.get $7)
           (local.tee $34
            (f64.add
             (f64.add
              (local.get $37)
              (f64.add
               (local.get $36)
               (f64.add
                (local.get $34)
                (local.get $33)
               )
              )
             )
             (f64.load
              (local.get $7)
             )
            )
           )
          )
          (local.set $7
           (i32.add
            (local.get $7)
            (i32.const -32)
           )
          )
          (br_if $label$87
           (i32.gt_u
            (local.tee $13
             (i32.add
              (local.get $13)
              (i32.const -4)
             )
            )
            (i32.const 1)
           )
          )
         )
        )
        (br_if $label$77
         (i32.lt_s
          (local.get $12)
          (i32.const 2)
         )
        )
        (local.set $6
         (i32.add
          (local.get $12)
          (i32.const 1)
         )
        )
        (local.set $7
         (i32.add
          (i32.add
           (local.get $5)
           (i32.const 160)
          )
          (i32.shl
           (local.get $16)
           (i32.const 3)
          )
         )
        )
        (local.set $34
         (f64.load
          (i32.add
           (i32.add
            (local.get $5)
            (i32.const 160)
           )
           (i32.shl
            (local.get $12)
            (i32.const 3)
           )
          )
         )
        )
        (loop $label$88
         (i64.store
          (i32.add
           (local.get $7)
           (i32.const 8)
          )
          (i64.const 0)
         )
         (f64.store
          (local.get $7)
          (local.tee $34
           (f64.add
            (local.get $34)
            (f64.load
             (local.get $7)
            )
           )
          )
         )
         (local.set $7
          (i32.add
           (local.get $7)
           (i32.const -8)
          )
         )
         (br_if $label$88
          (i32.gt_u
           (local.tee $6
            (i32.add
             (local.get $6)
             (i32.const -1)
            )
           )
           (i32.const 2)
          )
         )
        )
        (br_if $label$77
         (i32.lt_s
          (local.get $12)
          (i32.const 2)
         )
        )
        (local.set $13
         (i32.add
          (local.get $12)
          (i32.const -2)
         )
        )
        (br_if $label$79
         (local.tee $6
          (i32.and
           (local.get $16)
           (i32.const 3)
          )
         )
        )
        (local.set $35
         (f64.const 0)
        )
        (br $label$78)
       )
       (block $label$89
        (block $label$90
         (br_if $label$90
          (i32.ge_s
           (local.get $12)
           (i32.const 0)
          )
         )
         (local.set $34
          (f64.const 0)
         )
         (br $label$89)
        )
        (block $label$91
         (block $label$92
          (br_if $label$92
           (local.tee $13
            (i32.and
             (i32.add
              (local.get $12)
              (i32.const 1)
             )
             (i32.const 3)
            )
           )
          )
          (local.set $34
           (f64.const 0)
          )
          (local.set $6
           (local.get $12)
          )
          (br $label$91)
         )
         (local.set $7
          (i32.add
           (i32.add
            (local.get $5)
            (i32.const 160)
           )
           (i32.shl
            (local.get $12)
            (i32.const 3)
           )
          )
         )
         (local.set $34
          (f64.const 0)
         )
         (local.set $6
          (local.get $12)
         )
         (loop $label$93
          (local.set $6
           (i32.add
            (local.get $6)
            (i32.const -1)
           )
          )
          (local.set $34
           (f64.add
            (f64.load
             (local.get $7)
            )
            (local.get $34)
           )
          )
          (local.set $7
           (i32.add
            (local.get $7)
            (i32.const -8)
           )
          )
          (br_if $label$93
           (local.tee $13
            (i32.add
             (local.get $13)
             (i32.const -1)
            )
           )
          )
         )
        )
        (br_if $label$89
         (i32.lt_u
          (local.get $12)
          (i32.const 3)
         )
        )
        (local.set $13
         (i32.add
          (local.get $6)
          (i32.const 1)
         )
        )
        (local.set $7
         (i32.add
          (i32.add
           (i32.shl
            (local.get $6)
            (i32.const 3)
           )
           (i32.add
            (local.get $5)
            (i32.const 160)
           )
          )
          (i32.const -24)
         )
        )
        (loop $label$94
         (local.set $34
          (f64.add
           (f64.load
            (local.get $7)
           )
           (f64.add
            (f64.load
             (i32.add
              (local.get $7)
              (i32.const 8)
             )
            )
            (f64.add
             (f64.load
              (i32.add
               (local.get $7)
               (i32.const 16)
              )
             )
             (f64.add
              (f64.load
               (i32.add
                (local.get $7)
                (i32.const 24)
               )
              )
              (local.get $34)
             )
            )
           )
          )
         )
         (local.set $7
          (i32.add
           (local.get $7)
           (i32.const -32)
          )
         )
         (br_if $label$94
          (local.tee $13
           (i32.add
            (local.get $13)
            (i32.const -4)
           )
          )
         )
        )
       )
       (f64.store
        (local.get $1)
        (select
         (f64.neg
          (local.get $34)
         )
         (local.get $34)
         (local.get $31)
        )
       )
       (br $label$76)
      )
      (block $label$95
       (block $label$96
        (br_if $label$96
         (i32.ge_s
          (local.get $12)
          (i32.const 0)
         )
        )
        (local.set $34
         (f64.const 0)
        )
        (br $label$95)
       )
       (block $label$97
        (block $label$98
         (br_if $label$98
          (local.tee $13
           (i32.and
            (i32.add
             (local.get $12)
             (i32.const 1)
            )
            (i32.const 3)
           )
          )
         )
         (local.set $34
          (f64.const 0)
         )
         (local.set $6
          (local.get $12)
         )
         (br $label$97)
        )
        (local.set $7
         (i32.add
          (i32.add
           (local.get $5)
           (i32.const 160)
          )
          (i32.shl
           (local.get $12)
           (i32.const 3)
          )
         )
        )
        (local.set $34
         (f64.const 0)
        )
        (local.set $6
         (local.get $12)
        )
        (loop $label$99
         (local.set $6
          (i32.add
           (local.get $6)
           (i32.const -1)
          )
         )
         (local.set $34
          (f64.add
           (f64.load
            (local.get $7)
           )
           (local.get $34)
          )
         )
         (local.set $7
          (i32.add
           (local.get $7)
           (i32.const -8)
          )
         )
         (br_if $label$99
          (local.tee $13
           (i32.add
            (local.get $13)
            (i32.const -1)
           )
          )
         )
        )
       )
       (br_if $label$95
        (i32.lt_u
         (local.get $12)
         (i32.const 3)
        )
       )
       (local.set $13
        (i32.add
         (local.get $6)
         (i32.const 1)
        )
       )
       (local.set $7
        (i32.add
         (i32.add
          (i32.shl
           (local.get $6)
           (i32.const 3)
          )
          (i32.add
           (local.get $5)
           (i32.const 160)
          )
         )
         (i32.const -24)
        )
       )
       (loop $label$100
        (local.set $34
         (f64.add
          (f64.load
           (local.get $7)
          )
          (f64.add
           (f64.load
            (i32.add
             (local.get $7)
             (i32.const 8)
            )
           )
           (f64.add
            (f64.load
             (i32.add
              (local.get $7)
              (i32.const 16)
             )
            )
            (f64.add
             (f64.load
              (i32.add
               (local.get $7)
               (i32.const 24)
              )
             )
             (local.get $34)
            )
           )
          )
         )
        )
        (local.set $7
         (i32.add
          (local.get $7)
          (i32.const -32)
         )
        )
        (br_if $label$100
         (local.tee $13
          (i32.add
           (local.get $13)
           (i32.const -4)
          )
         )
        )
       )
      )
      (f64.store
       (local.get $1)
       (select
        (f64.neg
         (local.get $34)
        )
        (local.get $34)
        (local.get $31)
       )
      )
      (local.set $34
       (f64.sub
        (f64.load offset=160
         (local.get $5)
        )
        (local.get $34)
       )
      )
      (local.set $7
       (i32.const 1)
      )
      (block $label$101
       (br_if $label$101
        (i32.lt_s
         (local.get $12)
         (i32.const 1)
        )
       )
       (local.set $6
        (i32.and
         (local.get $12)
         (i32.const 3)
        )
       )
       (block $label$102
        (br_if $label$102
         (i32.lt_u
          (i32.add
           (local.get $12)
           (i32.const -1)
          )
          (i32.const 3)
         )
        )
        (local.set $16
         (i32.and
          (local.get $12)
          (i32.const -4)
         )
        )
        (local.set $7
         (i32.add
          (i32.add
           (local.get $5)
           (i32.const 160)
          )
          (i32.const 32)
         )
        )
        (local.set $13
         (i32.const 0)
        )
        (loop $label$103
         (local.set $34
          (f64.add
           (f64.load
            (local.get $7)
           )
           (f64.add
            (f64.load
             (i32.add
              (local.get $7)
              (i32.const -8)
             )
            )
            (f64.add
             (f64.load
              (i32.add
               (local.get $7)
               (i32.const -16)
              )
             )
             (f64.add
              (f64.load
               (i32.add
                (local.get $7)
                (i32.const -24)
               )
              )
              (local.get $34)
             )
            )
           )
          )
         )
         (local.set $7
          (i32.add
           (local.get $7)
           (i32.const 32)
          )
         )
         (br_if $label$103
          (i32.ne
           (local.get $16)
           (local.tee $13
            (i32.add
             (local.get $13)
             (i32.const 4)
            )
           )
          )
         )
        )
        (local.set $7
         (i32.add
          (local.get $13)
          (i32.const 1)
         )
        )
       )
       (br_if $label$101
        (i32.eqz
         (local.get $6)
        )
       )
       (local.set $7
        (i32.add
         (i32.add
          (local.get $5)
          (i32.const 160)
         )
         (i32.shl
          (local.get $7)
          (i32.const 3)
         )
        )
       )
       (loop $label$104
        (local.set $34
         (f64.add
          (f64.load
           (local.get $7)
          )
          (local.get $34)
         )
        )
        (local.set $7
         (i32.add
          (local.get $7)
          (i32.const 8)
         )
        )
        (br_if $label$104
         (local.tee $6
          (i32.add
           (local.get $6)
           (i32.const -1)
          )
         )
        )
       )
      )
      (f64.store offset=8
       (local.get $1)
       (select
        (f64.neg
         (local.get $34)
        )
        (local.get $34)
        (local.get $31)
       )
      )
      (br $label$76)
     )
     (local.set $7
      (i32.add
       (i32.add
        (local.get $5)
        (i32.const 160)
       )
       (i32.shl
        (local.get $12)
        (i32.const 3)
       )
      )
     )
     (local.set $35
      (f64.const 0)
     )
     (loop $label$105
      (local.set $12
       (i32.add
        (local.get $12)
        (i32.const -1)
       )
      )
      (local.set $35
       (f64.add
        (f64.load
         (local.get $7)
        )
        (local.get $35)
       )
      )
      (local.set $7
       (i32.add
        (local.get $7)
        (i32.const -8)
       )
      )
      (br_if $label$105
       (local.tee $6
        (i32.add
         (local.get $6)
         (i32.const -1)
        )
       )
      )
     )
    )
    (br_if $label$77
     (i32.lt_u
      (local.get $13)
      (i32.const 3)
     )
    )
    (local.set $6
     (i32.add
      (local.get $12)
      (i32.const 4)
     )
    )
    (local.set $7
     (i32.add
      (i32.add
       (i32.shl
        (local.get $12)
        (i32.const 3)
       )
       (i32.add
        (local.get $5)
        (i32.const 160)
       )
      )
      (i32.const -24)
     )
    )
    (loop $label$106
     (local.set $35
      (f64.add
       (f64.load
        (local.get $7)
       )
       (f64.add
        (f64.load
         (i32.add
          (local.get $7)
          (i32.const 8)
         )
        )
        (f64.add
         (f64.load
          (i32.add
           (local.get $7)
           (i32.const 16)
          )
         )
         (f64.add
          (f64.load
           (i32.add
            (local.get $7)
            (i32.const 24)
           )
          )
          (local.get $35)
         )
        )
       )
      )
     )
     (local.set $7
      (i32.add
       (local.get $7)
       (i32.const -32)
      )
     )
     (br_if $label$106
      (i32.gt_s
       (local.tee $6
        (i32.add
         (local.get $6)
         (i32.const -4)
        )
       )
       (i32.const 5)
      )
     )
    )
   )
   (local.set $34
    (f64.load offset=160
     (local.get $5)
    )
   )
   (block $label$107
    (br_if $label$107
     (local.get $31)
    )
    (f64.store
     (local.get $1)
     (local.get $34)
    )
    (f64.store offset=16
     (local.get $1)
     (local.get $35)
    )
    (f64.store offset=8
     (local.get $1)
     (f64.load offset=168
      (local.get $5)
     )
    )
    (br $label$76)
   )
   (f64.store
    (local.get $1)
    (f64.neg
     (local.get $34)
    )
   )
   (f64.store offset=16
    (local.get $1)
    (f64.neg
     (local.get $35)
    )
   )
   (f64.store offset=8
    (local.get $1)
    (f64.neg
     (f64.load offset=168
      (local.get $5)
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $5)
    (i32.const 560)
   )
  )
  (i32.and
   (local.get $29)
   (i32.const 7)
  )
 )
 (func $core_math___rem_pio2 (param $0 f64) (param $1 i32) (result i32)
  (local $2 i32)
  (local $3 i32)
  (local $4 i32)
  (local $5 i32)
  (local $6 i64)
  (local $7 f64)
  (local $8 f64)
  (local $9 f64)
  (global.set $__stack_pointer
   (local.tee $2
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 48)
    )
   )
  )
  (block $label$1
   (block $label$2
    (block $label$3
     (block $label$4
      (br_if $label$4
       (i32.gt_u
        (local.tee $4
         (i32.and
          (local.tee $3
           (i32.wrap_i64
            (i64.shr_u
             (local.tee $6
              (i64.reinterpret_f64
               (local.get $0)
              )
             )
             (i64.const 32)
            )
           )
          )
          (i32.const 2147483647)
         )
        )
        (i32.const 1074752122)
       )
      )
      (br_if $label$3
       (i32.eq
        (i32.and
         (local.get $3)
         (i32.const 1048575)
        )
        (i32.const 598523)
       )
      )
      (block $label$5
       (br_if $label$5
        (i32.gt_u
         (local.get $4)
         (i32.const 1073928572)
        )
       )
       (block $label$6
        (br_if $label$6
         (i64.lt_s
          (local.get $6)
          (i64.const 0)
         )
        )
        (i64.store offset=8
         (local.get $1)
         (i64.const 0)
        )
        (f64.store
         (local.get $1)
         (f64.add
          (local.get $0)
          (f64.const -1.5707963267948966)
         )
        )
        (local.set $3
         (i32.const 1)
        )
        (br $label$1)
       )
       (i64.store offset=8
        (local.get $1)
        (i64.const 4364452196894375936)
       )
       (f64.store
        (local.get $1)
        (f64.add
         (local.get $0)
         (f64.const 1.5707963267948966)
        )
       )
       (local.set $3
        (i32.const -1)
       )
       (br $label$1)
      )
      (block $label$7
       (br_if $label$7
        (i64.lt_s
         (local.get $6)
         (i64.const 0)
        )
       )
       (i64.store offset=8
        (local.get $1)
        (i64.const 0)
       )
       (f64.store
        (local.get $1)
        (f64.add
         (local.get $0)
         (f64.const -3.141592653589793)
        )
       )
       (local.set $3
        (i32.const 2)
       )
       (br $label$1)
      )
      (i64.store offset=8
       (local.get $1)
       (i64.const 4368955796521746432)
      )
      (f64.store
       (local.get $1)
       (f64.add
        (local.get $0)
        (f64.const 3.141592653589793)
       )
      )
      (local.set $3
       (i32.const -2)
      )
      (br $label$1)
     )
     (block $label$8
      (br_if $label$8
       (i32.gt_u
        (local.get $4)
        (i32.const 1075594811)
       )
      )
      (block $label$9
       (br_if $label$9
        (i32.gt_u
         (local.get $4)
         (i32.const 1075183036)
        )
       )
       (br_if $label$3
        (i32.eq
         (local.get $4)
         (i32.const 1074977148)
        )
       )
       (block $label$10
        (br_if $label$10
         (i64.lt_s
          (local.get $6)
          (i64.const 0)
         )
        )
        (i64.store offset=8
         (local.get $1)
         (i64.const 0)
        )
        (f64.store
         (local.get $1)
         (f64.add
          (local.get $0)
          (f64.const -4.71238898038469)
         )
        )
        (local.set $3
         (i32.const 3)
        )
        (br $label$1)
       )
       (i64.store offset=8
        (local.get $1)
        (i64.const 4371439675322138624)
       )
       (f64.store
        (local.get $1)
        (f64.add
         (local.get $0)
         (f64.const 4.71238898038469)
        )
       )
       (local.set $3
        (i32.const -3)
       )
       (br $label$1)
      )
      (br_if $label$3
       (i32.eq
        (local.get $4)
        (i32.const 1075388923)
       )
      )
      (block $label$11
       (br_if $label$11
        (i64.lt_s
         (local.get $6)
         (i64.const 0)
        )
       )
       (i64.store offset=8
        (local.get $1)
        (i64.const 0)
       )
       (f64.store
        (local.get $1)
        (f64.add
         (local.get $0)
         (f64.const -6.283185307179586)
        )
       )
       (local.set $3
        (i32.const 4)
       )
       (br $label$1)
      )
      (i64.store offset=8
       (local.get $1)
       (i64.const 4373459396149116928)
      )
      (f64.store
       (local.get $1)
       (f64.add
        (local.get $0)
        (f64.const 6.283185307179586)
       )
      )
      (local.set $3
       (i32.const -4)
      )
      (br $label$1)
     )
     (br_if $label$2
      (i32.gt_u
       (local.get $4)
       (i32.const 1094263290)
      )
     )
    )
    (local.set $5
     (f64.ge
      (local.tee $7
       (f64.mul
        (local.get $0)
        (f64.const -8.167195602330174e-17)
       )
      )
      (f64.const -0.7853981633974483)
     )
    )
    (block $label$12
     (block $label$13
      (br_if $label$13
       (i32.eqz
        (f64.lt
         (f64.abs
          (local.tee $8
           (f64.mul
            (local.get $0)
            (f64.const 0.6366197723675814)
           )
          )
         )
         (f64.const 2147483648)
        )
       )
      )
      (local.set $3
       (i32.trunc_f64_s
        (local.get $8)
       )
      )
      (br $label$12)
     )
     (local.set $3
      (i32.const -2147483648)
     )
    )
    (block $label$14
     (block $label$15
      (br_if $label$15
       (local.get $5)
      )
      (local.set $3
       (i32.add
        (local.get $3)
        (i32.const -1)
       )
      )
      (local.set $9
       (f64.mul
        (local.tee $8
         (f64.add
          (local.get $8)
          (f64.const -1)
         )
        )
        (f64.const 6.077100506506192e-11)
       )
      )
      (local.set $7
       (f64.add
        (local.get $0)
        (f64.mul
         (local.get $8)
         (f64.const -1.5707963267341256)
        )
       )
      )
      (br $label$14)
     )
     (block $label$16
      (br_if $label$16
       (i32.eqz
        (f64.le
         (local.get $7)
         (f64.const 0.7853981633974483)
        )
       )
      )
      (local.set $7
       (f64.mul
        (local.get $0)
        (f64.const 3.868794173911283e-11)
       )
      )
      (local.set $9
       (f64.mul
        (local.get $0)
        (f64.const 3.8688023411068853e-11)
       )
      )
      (br $label$14)
     )
     (local.set $3
      (i32.add
       (local.get $3)
       (i32.const 1)
      )
     )
     (local.set $9
      (f64.mul
       (local.tee $8
        (f64.add
         (local.get $8)
         (f64.const 1)
        )
       )
       (f64.const 6.077100506506192e-11)
      )
     )
     (local.set $7
      (f64.add
       (local.get $0)
       (f64.mul
        (local.get $8)
        (f64.const -1.5707963267341256)
       )
      )
     )
    )
    (f64.store
     (local.get $1)
     (local.tee $0
      (f64.sub
       (local.get $7)
       (local.get $9)
      )
     )
    )
    (block $label$17
     (br_if $label$17
      (i32.lt_s
       (i32.sub
        (local.tee $4
         (i32.shr_u
          (local.get $4)
          (i32.const 20)
         )
        )
        (i32.and
         (i32.wrap_i64
          (i64.shr_u
           (i64.reinterpret_f64
            (local.get $0)
           )
           (i64.const 52)
          )
         )
         (i32.const 2047)
        )
       )
       (i32.const 17)
      )
     )
     (f64.store
      (local.get $1)
      (local.tee $0
       (f64.sub
        (local.tee $7
         (f64.add
          (local.get $7)
          (f64.mul
           (local.get $8)
           (f64.const -6.077100506303966e-11)
          )
         )
        )
        (local.tee $9
         (f64.mul
          (local.get $8)
          (f64.const 2.0222662487959506e-21)
         )
        )
       )
      )
     )
     (br_if $label$17
      (i32.lt_s
       (i32.sub
        (local.get $4)
        (i32.and
         (i32.wrap_i64
          (i64.shr_u
           (i64.reinterpret_f64
            (local.get $0)
           )
           (i64.const 52)
          )
         )
         (i32.const 2047)
        )
       )
       (i32.const 50)
      )
     )
     (f64.store
      (local.get $1)
      (local.tee $0
       (f64.sub
        (local.tee $7
         (f64.add
          (local.get $7)
          (f64.mul
           (local.get $8)
           (f64.const -2.0222662487111665e-21)
          )
         )
        )
        (local.tee $9
         (f64.mul
          (local.get $8)
          (f64.const 8.4784276603689e-32)
         )
        )
       )
      )
     )
    )
    (f64.store offset=8
     (local.get $1)
     (f64.sub
      (local.get $7)
      (f64.add
       (local.get $9)
       (local.get $0)
      )
     )
    )
    (br $label$1)
   )
   (block $label$18
    (br_if $label$18
     (i32.lt_u
      (local.get $4)
      (i32.const 2146435072)
     )
    )
    (i64.store
     (local.get $1)
     (i64.const 0)
    )
    (i64.store offset=8
     (local.get $1)
     (i64.const 0)
    )
    (local.set $3
     (i32.const 0)
    )
    (br $label$1)
   )
   (f64.store offset=16
    (local.get $2)
    (local.tee $7
     (f64.trunc
      (local.tee $0
       (f64.reinterpret_i64
        (i64.or
         (i64.and
          (local.get $6)
          (i64.const 4503599627370495)
         )
         (i64.const 4710765210229538816)
        )
       )
      )
     )
    )
   )
   (f64.store offset=24
    (local.get $2)
    (local.tee $7
     (f64.trunc
      (local.tee $0
       (f64.mul
        (f64.sub
         (local.get $0)
         (local.get $7)
        )
        (f64.const 16777216)
       )
      )
     )
    )
   )
   (f64.store offset=32
    (local.get $2)
    (local.tee $0
     (f64.mul
      (f64.sub
       (local.get $0)
       (local.get $7)
      )
      (f64.const 16777216)
     )
    )
   )
   (block $label$19
    (block $label$20
     (br_if $label$20
      (f64.eq
       (local.get $0)
       (f64.const 0)
      )
     )
     (local.set $5
      (i32.const 2)
     )
     (br $label$19)
    )
    (local.set $3
     (i32.or
      (i32.add
       (local.get $2)
       (i32.const 16)
      )
      (i32.const 8)
     )
    )
    (local.set $5
     (i32.const 2)
    )
    (loop $label$21
     (local.set $5
      (i32.add
       (local.get $5)
       (i32.const -1)
      )
     )
     (local.set $0
      (f64.load
       (local.get $3)
      )
     )
     (local.set $3
      (i32.add
       (local.get $3)
       (i32.const -8)
      )
     )
     (br_if $label$21
      (f64.eq
       (local.get $0)
       (f64.const 0)
      )
     )
    )
   )
   (local.set $3
    (call $core_math___rem_pio2_large
     (i32.add
      (local.get $2)
      (i32.const 16)
     )
     (local.get $2)
     (i32.add
      (i32.shr_u
       (local.get $4)
       (i32.const 20)
      )
      (i32.const -1046)
     )
     (i32.add
      (local.get $5)
      (i32.const 1)
     )
     (i32.const 1)
    )
   )
   (local.set $0
    (f64.load
     (local.get $2)
    )
   )
   (block $label$22
    (br_if $label$22
     (i64.gt_s
      (local.get $6)
      (i64.const -1)
     )
    )
    (f64.store
     (local.get $1)
     (f64.neg
      (local.get $0)
     )
    )
    (f64.store offset=8
     (local.get $1)
     (f64.neg
      (f64.load offset=8
       (local.get $2)
      )
     )
    )
    (local.set $3
     (i32.sub
      (i32.const 0)
      (local.get $3)
     )
    )
    (br $label$1)
   )
   (f64.store
    (local.get $1)
    (local.get $0)
   )
   (f64.store offset=8
    (local.get $1)
    (f64.load offset=8
     (local.get $2)
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $2)
    (i32.const 48)
   )
  )
  (local.get $3)
 )
 (func $core_math_cos (param $0 f64) (result f64)
  (local $1 i32)
  (local $2 i32)
  (local $3 f64)
  (local $4 f64)
  (local $5 f64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.gt_u
      (local.tee $2
       (i32.and
        (i32.wrap_i64
         (i64.shr_u
          (i64.reinterpret_f64
           (local.get $0)
          )
          (i64.const 32)
         )
        )
        (i32.const 2147483647)
       )
      )
      (i32.const 1072243195)
     )
    )
    (block $label$3
     (br_if $label$3
      (i32.gt_u
       (local.get $2)
       (i32.const 1044816029)
      )
     )
     (f64.store
      (local.get $1)
      (f64.add
       (local.get $0)
       (f64.const 1329227995784915872903807e12)
      )
     )
     (local.set $3
      (f64.const 1)
     )
     (br $label$1)
    )
    (local.set $3
     (f64.add
      (f64.mul
       (f64.add
        (f64.add
         (f64.mul
          (f64.mul
           (local.tee $3
            (f64.mul
             (local.tee $0
              (f64.mul
               (local.get $0)
               (local.get $0)
              )
             )
             (local.get $0)
            )
           )
           (local.get $3)
          )
          (f64.add
           (f64.mul
            (f64.add
             (f64.mul
              (local.get $0)
              (f64.const -1.1359647557788195e-11)
             )
             (f64.const 2.087572321298175e-09)
            )
            (local.get $0)
           )
           (f64.const -2.7557314351390663e-07)
          )
         )
         (f64.const -0.5)
        )
        (f64.mul
         (f64.add
          (f64.mul
           (f64.add
            (f64.mul
             (local.get $0)
             (f64.const 2.480158728947673e-05)
            )
            (f64.const -0.001388888888887411)
           )
           (local.get $0)
          )
          (f64.const 0.0416666666666666)
         )
         (local.get $0)
        )
       )
       (local.get $0)
      )
      (f64.const 1)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (f64.const 0)
   )
   (br_if $label$1
    (i32.gt_u
     (local.get $2)
     (i32.const 2146435071)
    )
   )
   (block $label$4
    (block $label$5
     (block $label$6
      (block $label$7
       (br_table $label$7 $label$6 $label$5 $label$4
        (i32.and
         (call $core_math___rem_pio2
          (local.get $0)
          (local.get $1)
         )
         (i32.const 3)
        )
       )
      )
      (local.set $3
       (f64.add
        (f64.sub
         (f64.const 1)
         (f64.mul
          (f64.load offset=8
           (local.get $1)
          )
          (local.tee $0
           (f64.load
            (local.get $1)
           )
          )
         )
        )
        (f64.mul
         (f64.add
          (f64.add
           (f64.mul
            (f64.mul
             (local.tee $3
              (f64.mul
               (local.tee $0
                (f64.mul
                 (local.get $0)
                 (local.get $0)
                )
               )
               (local.get $0)
              )
             )
             (local.get $3)
            )
            (f64.add
             (f64.mul
              (f64.add
               (f64.mul
                (local.get $0)
                (f64.const -1.1359647557788195e-11)
               )
               (f64.const 2.087572321298175e-09)
              )
              (local.get $0)
             )
             (f64.const -2.7557314351390663e-07)
            )
           )
           (f64.const -0.5)
          )
          (f64.mul
           (f64.add
            (f64.mul
             (f64.add
              (f64.mul
               (local.get $0)
               (f64.const 2.480158728947673e-05)
              )
              (f64.const -0.001388888888887411)
             )
             (local.get $0)
            )
            (f64.const 0.0416666666666666)
           )
           (local.get $0)
          )
         )
         (local.get $0)
        )
       )
      )
      (br $label$1)
     )
     (local.set $3
      (f64.add
       (f64.sub
        (f64.mul
         (local.tee $4
          (f64.mul
           (local.tee $0
            (f64.mul
             (local.tee $3
              (f64.load
               (local.get $1)
              )
             )
             (local.get $3)
            )
           )
           (local.get $3)
          )
         )
         (f64.const 0.16666666666666632)
        )
        (f64.add
         (local.tee $5
          (f64.load offset=8
           (local.get $1)
          )
         )
         (local.get $3)
        )
       )
       (f64.mul
        (f64.add
         (f64.mul
          (local.get $5)
          (f64.const 0.5)
         )
         (f64.mul
          (f64.add
           (f64.mul
            (f64.add
             (f64.mul
              (f64.add
               (f64.mul
                (f64.add
                 (f64.mul
                  (local.get $0)
                  (f64.const -1.58969099521155e-10)
                 )
                 (f64.const 2.5050760253406863e-08)
                )
                (local.get $0)
               )
               (f64.const -2.7557313707070068e-06)
              )
              (local.get $0)
             )
             (f64.const 1.984126982985795e-04)
            )
            (local.get $0)
           )
           (f64.const -0.00833333333332249)
          )
          (local.get $4)
         )
        )
        (local.get $0)
       )
      )
     )
     (br $label$1)
    )
    (local.set $3
     (f64.add
      (f64.add
       (f64.mul
        (f64.load offset=8
         (local.get $1)
        )
        (local.tee $0
         (f64.load
          (local.get $1)
         )
        )
       )
       (f64.const -1)
      )
      (f64.mul
       (f64.add
        (f64.add
         (f64.mul
          (f64.mul
           (local.tee $3
            (f64.mul
             (local.tee $0
              (f64.mul
               (local.get $0)
               (local.get $0)
              )
             )
             (local.get $0)
            )
           )
           (local.get $3)
          )
          (f64.add
           (f64.mul
            (f64.add
             (f64.mul
              (local.get $0)
              (f64.const 1.1359647557788195e-11)
             )
             (f64.const -2.087572321298175e-09)
            )
            (local.get $0)
           )
           (f64.const 2.7557314351390663e-07)
          )
         )
         (f64.const 0.5)
        )
        (f64.mul
         (f64.add
          (f64.mul
           (f64.add
            (f64.mul
             (local.get $0)
             (f64.const -2.480158728947673e-05)
            )
            (f64.const 0.001388888888887411)
           )
           (local.get $0)
          )
          (f64.const -0.0416666666666666)
         )
         (local.get $0)
        )
       )
       (local.get $0)
      )
     )
    )
    (br $label$1)
   )
   (local.set $3
    (f64.add
     (f64.add
      (f64.add
       (local.tee $4
        (f64.load offset=8
         (local.get $1)
        )
       )
       (local.tee $3
        (f64.load
         (local.get $1)
        )
       )
      )
      (f64.mul
       (local.tee $3
        (f64.mul
         (local.tee $0
          (f64.mul
           (local.get $3)
           (local.get $3)
          )
         )
         (local.get $3)
        )
       )
       (f64.const -0.16666666666666632)
      )
     )
     (f64.mul
      (f64.add
       (f64.mul
        (f64.add
         (f64.mul
          (f64.add
           (f64.mul
            (f64.add
             (f64.mul
              (f64.add
               (f64.mul
                (local.get $0)
                (f64.const 1.58969099521155e-10)
               )
               (f64.const -2.5050760253406863e-08)
              )
              (local.get $0)
             )
             (f64.const 2.7557313707070068e-06)
            )
            (local.get $0)
           )
           (f64.const -1.984126982985795e-04)
          )
          (local.get $0)
         )
         (f64.const 0.00833333333332249)
        )
        (local.get $3)
       )
       (f64.mul
        (local.get $4)
        (f64.const -0.5)
       )
      )
      (local.get $0)
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (local.get $3)
 )
 (func $core_math_sin (param $0 f64) (result f64)
  (local $1 i32)
  (local $2 i32)
  (local $3 f64)
  (local $4 f64)
  (local $5 f64)
  (global.set $__stack_pointer
   (local.tee $1
    (i32.sub
     (global.get $__stack_pointer)
     (i32.const 16)
    )
   )
  )
  (block $label$1
   (block $label$2
    (br_if $label$2
     (i32.gt_u
      (local.tee $2
       (i32.and
        (i32.wrap_i64
         (i64.shr_u
          (i64.reinterpret_f64
           (local.get $0)
          )
          (i64.const 32)
         )
        )
        (i32.const 2147483647)
       )
      )
      (i32.const 1072243195)
     )
    )
    (block $label$3
     (br_if $label$3
      (i32.gt_u
       (local.get $2)
       (i32.const 1045430271)
      )
     )
     (f64.store
      (local.get $1)
      (select
       (f64.mul
        (local.get $0)
        (f64.const 7.52316384526264e-37)
       )
       (f64.add
        (local.get $0)
        (f64.const 1329227995784915872903807e12)
       )
       (i32.lt_u
        (local.get $2)
        (i32.const 1048576)
       )
      )
     )
     (local.set $3
      (local.get $0)
     )
     (br $label$1)
    )
    (local.set $3
     (f64.add
      (f64.mul
       (f64.mul
        (local.tee $3
         (f64.mul
          (local.get $0)
          (local.get $0)
         )
        )
        (local.get $0)
       )
       (f64.add
        (f64.mul
         (f64.add
          (f64.mul
           (f64.add
            (f64.mul
             (f64.add
              (f64.mul
               (f64.add
                (f64.mul
                 (local.get $3)
                 (f64.const 1.58969099521155e-10)
                )
                (f64.const -2.5050760253406863e-08)
               )
               (local.get $3)
              )
              (f64.const 2.7557313707070068e-06)
             )
             (local.get $3)
            )
            (f64.const -1.984126982985795e-04)
           )
           (local.get $3)
          )
          (f64.const 0.00833333333332249)
         )
         (local.get $3)
        )
        (f64.const -0.16666666666666632)
       )
      )
      (local.get $0)
     )
    )
    (br $label$1)
   )
   (local.set $3
    (f64.const 0)
   )
   (br_if $label$1
    (i32.gt_u
     (local.get $2)
     (i32.const 2146435071)
    )
   )
   (block $label$4
    (block $label$5
     (block $label$6
      (block $label$7
       (br_table $label$7 $label$6 $label$5 $label$4
        (i32.and
         (call $core_math___rem_pio2
          (local.get $0)
          (local.get $1)
         )
         (i32.const 3)
        )
       )
      )
      (local.set $3
       (f64.add
        (f64.add
         (f64.add
          (local.tee $4
           (f64.load offset=8
            (local.get $1)
           )
          )
          (local.tee $3
           (f64.load
            (local.get $1)
           )
          )
         )
         (f64.mul
          (local.tee $3
           (f64.mul
            (local.tee $0
             (f64.mul
              (local.get $3)
              (local.get $3)
             )
            )
            (local.get $3)
           )
          )
          (f64.const -0.16666666666666632)
         )
        )
        (f64.mul
         (f64.add
          (f64.mul
           (f64.add
            (f64.mul
             (f64.add
              (f64.mul
               (f64.add
                (f64.mul
                 (f64.add
                  (f64.mul
                   (local.get $0)
                   (f64.const 1.58969099521155e-10)
                  )
                  (f64.const -2.5050760253406863e-08)
                 )
                 (local.get $0)
                )
                (f64.const 2.7557313707070068e-06)
               )
               (local.get $0)
              )
              (f64.const -1.984126982985795e-04)
             )
             (local.get $0)
            )
            (f64.const 0.00833333333332249)
           )
           (local.get $3)
          )
          (f64.mul
           (local.get $4)
           (f64.const -0.5)
          )
         )
         (local.get $0)
        )
       )
      )
      (br $label$1)
     )
     (local.set $3
      (f64.add
       (f64.sub
        (f64.const 1)
        (f64.mul
         (f64.load offset=8
          (local.get $1)
         )
         (local.tee $0
          (f64.load
           (local.get $1)
          )
         )
        )
       )
       (f64.mul
        (f64.add
         (f64.add
          (f64.mul
           (f64.mul
            (local.tee $3
             (f64.mul
              (local.tee $0
               (f64.mul
                (local.get $0)
                (local.get $0)
               )
              )
              (local.get $0)
             )
            )
            (local.get $3)
           )
           (f64.add
            (f64.mul
             (f64.add
              (f64.mul
               (local.get $0)
               (f64.const -1.1359647557788195e-11)
              )
              (f64.const 2.087572321298175e-09)
             )
             (local.get $0)
            )
            (f64.const -2.7557314351390663e-07)
           )
          )
          (f64.const -0.5)
         )
         (f64.mul
          (f64.add
           (f64.mul
            (f64.add
             (f64.mul
              (local.get $0)
              (f64.const 2.480158728947673e-05)
             )
             (f64.const -0.001388888888887411)
            )
            (local.get $0)
           )
           (f64.const 0.0416666666666666)
          )
          (local.get $0)
         )
        )
        (local.get $0)
       )
      )
     )
     (br $label$1)
    )
    (local.set $3
     (f64.add
      (f64.sub
       (f64.mul
        (local.tee $4
         (f64.mul
          (local.tee $0
           (f64.mul
            (local.tee $3
             (f64.load
              (local.get $1)
             )
            )
            (local.get $3)
           )
          )
          (local.get $3)
         )
        )
        (f64.const 0.16666666666666632)
       )
       (f64.add
        (local.tee $5
         (f64.load offset=8
          (local.get $1)
         )
        )
        (local.get $3)
       )
      )
      (f64.mul
       (f64.add
        (f64.mul
         (local.get $5)
         (f64.const 0.5)
        )
        (f64.mul
         (f64.add
          (f64.mul
           (f64.add
            (f64.mul
             (f64.add
              (f64.mul
               (f64.add
                (f64.mul
                 (local.get $0)
                 (f64.const -1.58969099521155e-10)
                )
                (f64.const 2.5050760253406863e-08)
               )
               (local.get $0)
              )
              (f64.const -2.7557313707070068e-06)
             )
             (local.get $0)
            )
            (f64.const 1.984126982985795e-04)
           )
           (local.get $0)
          )
          (f64.const -0.00833333333332249)
         )
         (local.get $4)
        )
       )
       (local.get $0)
      )
     )
    )
    (br $label$1)
   )
   (local.set $3
    (f64.add
     (f64.add
      (f64.mul
       (f64.load offset=8
        (local.get $1)
       )
       (local.tee $0
        (f64.load
         (local.get $1)
        )
       )
      )
      (f64.const -1)
     )
     (f64.mul
      (f64.add
       (f64.add
        (f64.mul
         (f64.mul
          (local.tee $3
           (f64.mul
            (local.tee $0
             (f64.mul
              (local.get $0)
              (local.get $0)
             )
            )
            (local.get $0)
           )
          )
          (local.get $3)
         )
         (f64.add
          (f64.mul
           (f64.add
            (f64.mul
             (local.get $0)
             (f64.const 1.1359647557788195e-11)
            )
            (f64.const -2.087572321298175e-09)
           )
           (local.get $0)
          )
          (f64.const 2.7557314351390663e-07)
         )
        )
        (f64.const 0.5)
       )
       (f64.mul
        (f64.add
         (f64.mul
          (f64.add
           (f64.mul
            (local.get $0)
            (f64.const -2.480158728947673e-05)
           )
           (f64.const 0.001388888888887411)
          )
          (local.get $0)
         )
         (f64.const -0.0416666666666666)
        )
        (local.get $0)
       )
      )
      (local.get $0)
     )
    )
   )
  )
  (global.set $__stack_pointer
   (i32.add
    (local.get $1)
    (i32.const 16)
   )
  )
  (local.get $3)
 )
 ;; custom section "producers", size 28
)

